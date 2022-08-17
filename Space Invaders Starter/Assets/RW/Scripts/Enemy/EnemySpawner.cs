using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyDefenders
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] public GameObject[] enemyPrefabs;
		[SerializeField] public Transform[] spawnPoints;
		[SerializeField] public List<GameObject> spawnedEnemies = new List<GameObject>();
		[SerializeField] private EnemyBulletSpawner enemyBulletSpawnerPrefab;

		internal static EnemySpawner Instance;

		private int columnCount;
		private int enemyCount = 20;
		public int randomEnemy;
		public int randomSpawnPoint;
		public GameObject enemy;
		//bool spawnTimeDelay = true;

		public IEnumerator SpawnEnemyWave()
		{
			columnCount = Random.Range(5, 10);

			if (enemyCount != 0)
			{
				if (enemyCount < columnCount)
				{
					columnCount = enemyCount;

					for (int i = 0; i < columnCount; i++)
					{
						randomEnemy = Random.Range(0, enemyPrefabs.Length);
						randomSpawnPoint = Random.Range(0, spawnPoints.Length);
						enemy = Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawnPoint].position, transform.rotation);
						spawnedEnemies.Add(enemy);
					}
					enemyCount = 0;
				}

				else if (enemyCount > columnCount)
				{
					enemyCount -= columnCount;

					for (int i = 0; i < columnCount; i++)
					{
						randomEnemy = Random.Range(0, enemyPrefabs.Length);
						randomSpawnPoint = Random.Range(0, spawnPoints.Length);

						enemy = Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawnPoint].position, transform.rotation);
						spawnedEnemies.Add(enemy);
					}
					yield return new WaitForSeconds(3f);
					StartCoroutine(SpawnEnemyWave());
				}
			}

			else if (enemyCount == 0)
			{
				yield return null;
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

		void Start()
		{
			StartCoroutine(SpawnEnemyWave());
			/*while(spawnTimeDelay)
      {
  StartCoroutine(SpawnEnemyWave());
}*/
		}

		void Update()
		{
			//StartCoroutine(SpawnEnemyWave());

			/*timer += Time.deltaTime;
			if (timer < spawnTimeDelay)
			{
					return;
			}
			else
			{
					StartCoroutine(SpawnEnemyWave(spawnTimeDelay));
			}*/
		}
	}
}
