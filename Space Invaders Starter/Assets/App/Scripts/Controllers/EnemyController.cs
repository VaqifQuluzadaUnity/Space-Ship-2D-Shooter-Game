using UnityEngine;
using GalaxyDefenders.Music_SFX;
using GalaxyDefenders.Managers;
using GalaxyDefenders.Spawners;

namespace GalaxyDefenders.Controllers
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

            gameObject.transform.Translate(0, -yDecrement, 0);

            currentY -= yDecrement;

            if (gameObject.transform.position.y < -170)
            {
                GameManager.Instance.TriggerGameOver(true);
            }
        }

        public void SetCannonPos(Transform cannonPos)
        {
            cannonPosition = cannonPos;
        }

        public void SetMusic(MusicControl music)
        {
            musicControl = music;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {

            if (!other.collider.GetComponent<Bullet>())
            {
                return;
            }
            gameObject.SetActive(false);
            EnemySpawner.Instance.enemyPool.Push(gameObject);
            GameManager.Instance.UpdateScore(UI_Controller.Instance.GetPoints());
            MusicControl.Instance.IncreaseDeathCount();
        }
    }
}
