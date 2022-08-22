using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyDefenders
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform cannonPosition;
        [SerializeField] private float speedFactor = 10f;
        [SerializeField] private MusicControl musicControl;

        private float currentY;
        private float minY;
        private float yDecrement;

        void Start()
        {
            currentY = EnemySpawner.Instance.spawnPoints[EnemySpawner.Instance.randomSpawnPoint].position.y;
            minY = cannonPosition.position.y;
        }

        void Update()
        {
            yDecrement = speedFactor * musicControl.Tempo * Time.deltaTime;

            MoveInvaders();

            currentY -= yDecrement;

            if (currentY < minY)
            {
                GameManager.Instance.TriggerGameOver(true);
            }
        }

        private void MoveInvaders()
        {
            foreach (GameObject enemy in EnemySpawner.Instance.spawnedEnemies)
            {
                enemy.transform.Translate(0, -yDecrement, 0);
            }
        }

    public void SetCannonPos(Transform cannonPos)
		{
      cannonPosition = cannonPos;
		}
    }
}
