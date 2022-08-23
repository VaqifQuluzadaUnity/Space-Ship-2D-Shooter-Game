using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyDefenders
{
	public class EnemyMethods : MonoBehaviour
	{
		[SerializeField] private MusicControl musicControl;

		private int points = 0;
		private int killCount;
		private int enemyCount = 20;
		private int tempKillCount;

		public void SetMusic(MusicControl music)
		{
			musicControl = music;
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
			
			if (tempKillCount < (enemyCount / musicControl.pitchChangeSteps))
			{
				Debug.Log("1");
				return;
			}
            else
            {
				musicControl.IncreasePitch();
				Debug.Log("2");
				tempKillCount = 0;
			}
		}

		internal int GetPoints()
		{
			points++;
			return points;
		}

		private void OnCollisionEnter2D(Collision2D other)
		{

			if (!other.collider.GetComponent<Bullet>())
			{
				return;
			}
			gameObject.SetActive(false);
			EnemySpawner.Instance.enemyPool.Push(gameObject);
			GameManager.Instance.UpdateScore(GetPoints());
			IncreaseDeathCount();
		}
	}
}
