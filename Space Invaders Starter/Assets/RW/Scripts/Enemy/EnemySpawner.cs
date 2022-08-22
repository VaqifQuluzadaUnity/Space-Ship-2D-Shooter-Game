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
		[SerializeField] public Stack<GameObject> enemyPool = new Stack<GameObject>();
		[SerializeField] private EnemyBulletSpawner enemyBulletSpawnerPrefab;
		[SerializeField] private Transform cannonPos;
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

			yield return new WaitForSeconds(5f);

			if (enemyCount != 0)
			{
				if (enemyCount < columnCount)
				{
					columnCount = enemyCount;

					for (int i = 0; i < columnCount; i++)
					{
						randomSpawnPoint = Random.Range(0, spawnPoints.Length);
						enemy = enemyPool.Pop();
						enemy.transform.position = spawnPoints[randomSpawnPoint].position;
						enemy.SetActive(true);
						spawnedEnemies.Add(enemy);
					}
					enemyCount = 0;
				}

				else if (enemyCount > columnCount)
				{
					enemyCount -= columnCount;

					for (int i = 0; i < columnCount; i++)
					{
						
						randomSpawnPoint = Random.Range(0, spawnPoints.Length);
						Debug.Log(enemyPool.Count);
						enemy = enemyPool.Pop();
						spawnedEnemies.Add(enemy);
						enemy.transform.position = spawnPoints[randomSpawnPoint].position;
						enemy.SetActive(true);
						
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

		private void CheckPool()
		{
			if (enemyPool.Count < 200)
			{
				int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
				enemy = Instantiate(enemyPrefabs[randomEnemyIndex],transform);
				enemy.GetComponent<EnemyController>().SetCannonPos(cannonPos);
				enemy.SetActive(false);
				enemyPool.Push(enemy);
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

			InvokeRepeating("CheckPool", 0, 0.05f);
		}
	}
}
