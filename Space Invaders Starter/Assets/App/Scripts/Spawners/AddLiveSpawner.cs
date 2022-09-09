using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GalaxyDefenders.Music_SFX;

namespace GalaxyDefenders.Spawners
{
    public class AddLiveSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject live;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] public List<GameObject> spawnedLives = new List<GameObject>();
        [SerializeField] public Stack<GameObject> addLivePool = new Stack<GameObject>();

        internal static AddLiveSpawner Instance;

        private int randomSpawnPoint;
        private GameObject addLive;

        IEnumerator SpawnLives()
        {
            yield return new WaitForSeconds(20f);

            randomSpawnPoint = Random.Range(0, spawnPoints.Length);

            addLive = addLivePool.Pop();
            addLive.transform.position = spawnPoints[randomSpawnPoint].position;
            addLive.SetActive(true);
            spawnedLives.Add(addLive);

            StartCoroutine(SpawnLives());

        }

        private void Start()
        {
            StartCoroutine(SpawnLives());
            InvokeRepeating("CheckPool", 0, 0.05f);
        }

        private void CheckPool()
        {
            if (addLivePool.Count < 200)
            {
                addLive = Instantiate(live, transform);
                addLive.SetActive(false);
                addLivePool.Push(addLive);
            }
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
    }
}

