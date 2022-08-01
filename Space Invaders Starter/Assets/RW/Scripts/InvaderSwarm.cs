/*
 * Copyright (c) 2021 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RayWenderlich.SpaceInvadersUnity
{
    public class InvaderSwarm : MonoBehaviour
    {
        [System.Serializable]
        private struct InvaderType
        {
            public string name;
            public Sprite[] sprites;
            public int points;
            public int rowCount;
        }

        internal static InvaderSwarm Instance;

        [Header("Spawning")]
        [SerializeField]
        private InvaderType[] invaderTypes;

        //[SerializeField]
        private int columnCount;

        [SerializeField]
        private int ySpacing;

        //[SerializeField]
        private int xSpacing;

        [SerializeField]
        private Transform[] spawnStartPoint;

        private float minX;

        [Space]
        [Header("Movement")]
        [SerializeField]
        private float speedFactor = 10f;

        private Transform[,] invaders;
        private int rowCount;
        private float maxX;
        private float currentX;
        private float xIncrement;

        [SerializeField]
        private BulletSpawner bulletSpawnerPrefab;

        private int killCount;
        private System.Collections.Generic.Dictionary<string, int> pointsMap;

        [SerializeField]
        private MusicControl musicControl;

        private int tempKillCount;

        [SerializeField]
        private Transform cannonPosition;

        private float minY;
        private float currentY;

        private int a = 20;

        public IEnumerator SpawnEnemyWave(float n)
        {
            n = 3f;

            columnCount = Random.Range(3, 6);

            if(a != 0)
            {
                if (a < columnCount)
                {
                    columnCount = a;

                    //burda ise enemyleri spawn edirik
                    for (int i = 0; i < rowCount; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            //enemy-ni spawn edeceyimiz random noqteni teyin edirik.
                            int randomSpawnIndex = Random.Range(0, spawnStartPoint.Length);

                            //Enemy-nin pozisiyasini bizim spawn pointe yerlestiririk.
                            invaders[i, j].transform.position = spawnStartPoint[randomSpawnIndex].position;

                            yield return new WaitForSeconds(n);
                        }
                    }

                    a = 0;
                }
                else if (a > columnCount)
                {
                    a -= columnCount;

                    //burda ise enemyleri spawn edirik
                    for (int i = 0; i < rowCount; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            //enemy-ni spawn edeceyimiz random noqteni teyin edirik.
                            int randomSpawnIndex = Random.Range(0, spawnStartPoint.Length);

                            //Enemy-nin pozisiyasini bizim spawn pointe yerlestiririk.
                            invaders[i, j].transform.position = spawnStartPoint[randomSpawnIndex].position;

                            yield return new WaitForSeconds(n);
                        }
                    }
                }
            }
            else if(a== 0)
            {

            }
        }

        IEnumerator Miyau(float n)
        {
            n = 3f;
            for (int i = 0; i < 4; i++)
            {
                StartCoroutine(SpawnEnemyWave(n));
                yield return new WaitForSeconds(n);
            }
        }

        internal void IncreaseDeathCount()
        {
            killCount++;
            if (killCount >= invaders.Length)
            {
                GameManager.Instance.TriggerGameOver(false);
                return;
            }
            tempKillCount++;
            if (tempKillCount < invaders.Length / musicControl.pitchChangeSteps)
            {
                return;
            }

            musicControl.IncreasePitch();
            tempKillCount = 0;

        }

        internal int GetPoints(string alienName)
        {
            if (pointsMap.ContainsKey(alienName))
            {
                return pointsMap[alienName];
            }
            return 0;
        }

        internal Transform GetInvader(int row, int column)
        {
            if (row < 0 || column < 0
                || row >= invaders.GetLength(0) || column >= invaders.GetLength(1))
            {
                return null;
            }

            return invaders[row, column];
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            xSpacing = Random.Range(25, 30);

            float spawnTimeDelay = 3f;
            StartCoroutine(Miyau(spawnTimeDelay));

            currentY = spawnStartPoint[Random.Range(0, spawnStartPoint.Length)].position.y;
            minY = cannonPosition.position.y;

            minX = spawnStartPoint[Random.Range(0, spawnStartPoint.Length)].position.x;

            GameObject swarm = new GameObject { name = "Swarm" };
            Vector2 currentPos = spawnStartPoint[Random.Range(0, spawnStartPoint.Length)].position;

            foreach (var invaderType in invaderTypes)
            {
                rowCount += invaderType.rowCount;
            }
            maxX = minX + 2f * xSpacing * columnCount;
            currentX = minX;
            invaders = new Transform[rowCount, columnCount];

            pointsMap = new System.Collections.Generic.Dictionary<string, int>();

            int rowIndex = 0;
            foreach (var invaderType in invaderTypes)
            {
                var invaderName = invaderType.name.Trim();
                pointsMap[invaderName] = invaderType.points;
                for (int i = 0, len = invaderType.rowCount; i < len; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        var invader = new GameObject() { name = invaderName };
                        invader.AddComponent<SimpleAnimator>().sprites = invaderType.sprites;
                        invader.transform.position = currentPos;
                        invader.transform.SetParent(swarm.transform);
                        invaders[rowIndex, j] = invader.transform;
                        currentPos.x += xSpacing;
                    }

                    currentPos.x = minX;
                    currentPos.y -= ySpacing;

                    rowIndex++;
                }
            }

            for (int i = 0; i < columnCount; i++)
            {
                var bulletSpawner = Instantiate(bulletSpawnerPrefab);
                bulletSpawner.transform.SetParent(swarm.transform);
                bulletSpawner.column = i;
                bulletSpawner.currentRow = rowCount - 1;
                bulletSpawner.Setup();
            }
        }

        private void Update()
        {
            xIncrement = speedFactor * musicControl.Tempo * Time.deltaTime;
            MoveInvaders(0, -xIncrement);
            currentY -= xIncrement;
            if (currentY < minY)
            {
                GameManager.Instance.TriggerGameOver();
            }

        }

        private void MoveInvaders(float x, float y)
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    invaders[i, j].Translate(x, y, 0);
                }
            }
        }
    }
}