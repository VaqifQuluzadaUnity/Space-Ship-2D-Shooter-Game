using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		[SerializeField] public List<GameObject> spawnedEnemies = new List<GameObject>();
		internal static InvaderSwarm Instance;

		private int columnCount;
		private int enemyCount = 20;
		private int points = 0;
		private float yDecrement=1;
		private float xSpacing;
		private int killCount;
		private int tempKillCount;
		private float minY;
		private float currentY;
		public int randomEnemy;
		public int randomSpawnPoint;
		private float minTime=1f;
		private float maxTime=10f;
		private float timer;
		private float currentTime;

		GameObject enemy;

		public IEnumerator SpawnEnemyWave(float n)
		{
			n = 3f;
			
			columnCount = Random.Range(1, 6);

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
					
					yield return new WaitForSeconds(n);
				}
			}

			else if (enemyCount == 0)
			{

			}
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
			xSpacing = Random.Range(25, 30);

			currentY = spawnPoints[randomSpawnPoint].position.y;
			minY = cannonPosition.position.y;
		}

		private void Update()
		{
			StartCoroutine(SpawnEnemyWave(spawnTimeDelay));

			yDecrement = speedFactor * musicControl.Tempo * Time.deltaTime;
			
			MoveInvaders();

			currentY -= yDecrement;

			if (currentY < minY)
			{
				GameManager.Instance.TriggerGameOver();
			}

			timer += Time.deltaTime;
			currentTime = Random.Range(minTime, maxTime);
			if (timer < currentTime)
			{
				return;
			}
			else
			{
				var bulletSpawner = Instantiate(bulletSpawnerPrefab);
				bulletSpawner.transform.SetParent(enemy.transform);
				bulletSpawner.Setup();
			}
			timer = 0f;

		}

		private void MoveInvaders()
		{
			foreach(GameObject enemy in spawnedEnemies)
			{
				enemy.transform.Translate(0, -yDecrement, 0);
				
			}
		}
	}


}