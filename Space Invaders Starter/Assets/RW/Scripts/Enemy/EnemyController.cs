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
            currentY = gameObject.transform.position.y;
            minY = cannonPosition.position.y;
        }

        void Update()
        {
            yDecrement = speedFactor * musicControl.Tempo * Time.deltaTime;

            MoveInvaders();

            currentY -= yDecrement;

            if (gameObject.transform.position.y < -170)
            {
                GameManager.Instance.TriggerGameOver(true);
                Debug.Log("1");
            }
        }

        private void MoveInvaders()
        {
            gameObject.transform.Translate(0, -yDecrement, 0);

        }

        public void SetCannonPos(Transform cannonPos)
        {
            cannonPosition = cannonPos;
        }

        public void SetMusic(MusicControl music)
        {
            musicControl = music;
        }
    }
}
