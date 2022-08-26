using UnityEngine;
using GalaxyDefenders.Music_SFX;
using GalaxyDefenders.Managers;
using GalaxyDefenders.Spawners;
using GalaxyDefenders.MVC;

namespace GalaxyDefenders.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float speedFactor = 10f;
        [SerializeField] private MusicControl musicControl;

        private float currentY;
        private float yDecrement;

        void Start()
        {
            currentY = gameObject.transform.position.y;
        }

        void Update()
        {
            yDecrement = speedFactor * musicControl.Tempo * Time.deltaTime;

            gameObject.transform.Translate(0, -yDecrement, 0);

            currentY -= yDecrement;

            if (currentY < -170)
            {
                GameManager.Instance.TriggerGameOver(true);
            }
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
            UIView.Instance.GetPoints();
            MusicControl.Instance.IncreaseDeathCount();
        }
    }
}
