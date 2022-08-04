using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GalaxyDefenders
{
    public class InvaderSwarm : MonoBehaviour
    {
        [SerializeField] Transform[] spawnPoints;
        [SerializeField] public GameObject[] enemyPrefabs;
        [SerializeField] private float speedFactor = 10f;
        [SerializeField] private BulletSpawner bulletSpawnerPrefab;
        [SerializeField] private MusicControl musicControl;
        [SerializeField] private Transform cannonPosition;

        internal static InvaderSwarm Instance;

        private int columnCount;
        private int enemyCount=20;
        private int points = 0;
        private float yDecrement;
        private float xSpacing;
        private int killCount;
        private int tempKillCount;
        private float minY;
        private float currentY;
        public int randomEnemy = Random.Range(0, 3);
        public int randomSpawnPoint = Random.Range(0, 43);

        GameObject swarm = new GameObject { name = "Swarm" };

        public IEnumerator SpawnEnemyWave(float n)
        {
            n = 3f;

            columnCount = Random.Range(1, 6);

            if(enemyCount != 0)
            {
                if (enemyCount < columnCount)
                {
                    columnCount = enemyCount;
                    
                    for(int i= 0; i < columnCount; i++)
                    {
                        Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawnPoint].position, transform.rotation);
                    }
                }
                enemyCount = 0;
            }

            else if (enemyCount > columnCount)
            {
                enemyCount -= columnCount;

                Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawnPoint].position, transform.rotation);
            }

            else if(enemyCount == 0)
            {

            }

            yield return new WaitForSeconds(n);
        }

        internal void IncreaseDeathCount()
        {
            killCount++;
            if (killCount == enemyCount)
            {
                GameManager.Instance.TriggerGameOver(false);
                return;
            }
            tempKillCount++;
            if (tempKillCount < enemyCount / musicControl.pitchChangeSteps)
            {
                return;
            }

            musicControl.IncreasePitch();
            tempKillCount = 0;
        }

        internal int GetPoints()
        {
            points++;
            return 0;
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

        float spawnTimeDelay = 3f;

        private void Start()
        {
            StartCoroutine(SpawnEnemyWave(spawnTimeDelay));

            xSpacing = Random.Range(25, 30);

            currentY = spawnPoints[randomSpawnPoint].position.y;
            minY = cannonPosition.position.y;

            for (int i = 0; i < columnCount; i++)
            {
                var bulletSpawner = Instantiate(bulletSpawnerPrefab);
                bulletSpawner.transform.SetParent(swarm.transform);
                bulletSpawner.Setup();
            }
        }

        private void Update()
        {
            yDecrement = speedFactor * musicControl.Tempo * Time.deltaTime;

            MoveInvaders(-yDecrement);

            currentY -= yDecrement;

            if (currentY < minY)
            {
                GameManager.Instance.TriggerGameOver();
            }

        }

        private void MoveInvaders(float y)
        {
            enemyPrefabs[1].transform.Translate(0, y, 0);
        }
    }
}