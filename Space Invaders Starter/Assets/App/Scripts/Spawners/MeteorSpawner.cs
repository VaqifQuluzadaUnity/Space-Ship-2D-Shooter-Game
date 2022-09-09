using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GalaxyDefenders.Music_SFX;

namespace GalaxyDefenders.Spawners
{
    public class MeteorSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] meteors;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] public List<GameObject> spawnedMeteors = new List<GameObject>();
        [SerializeField] public Stack<GameObject> meteorPool = new Stack<GameObject>();

        internal static MeteorSpawner Instance;

        private int randomSpawnPoint;
        private GameObject meteor;

        IEnumerator SpawnMeteors()
        {
            yield return new WaitForSeconds(3f);

            randomSpawnPoint = Random.Range(0, spawnPoints.Length);

            meteor = meteorPool.Pop();
            meteor.transform.position = spawnPoints[randomSpawnPoint].position;
            meteor.SetActive(true);
            spawnedMeteors.Add(meteor);

            StartCoroutine(SpawnMeteors());

        }

        private void Start()
        {
            StartCoroutine(SpawnMeteors());
            InvokeRepeating("CheckPool", 0, 0.05f);
        }

        private void CheckPool()
        {
            if (meteorPool.Count < 200)
            {
                int randomMeteor = Random.Range(0, meteors.Length);
                meteor = Instantiate(meteors[randomMeteor], transform);
                meteor.SetActive(false);
                meteorPool.Push(meteor);
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
