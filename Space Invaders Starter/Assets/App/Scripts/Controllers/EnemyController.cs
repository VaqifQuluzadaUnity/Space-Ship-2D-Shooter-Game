using UnityEngine;
using GalaxyDefenders.Music_SFX;
using GalaxyDefenders.Managers;
using GalaxyDefenders.Spawners;
using GalaxyDefenders.MVC;
using DynamicBox.EventManagement;

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
                EventManager.Instance.Raise(new TriggerGameOverEvent(true));
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
            EventManager.Instance.Raise(new ScoreEvent(Random.Range(3, 6)));
           MusicControl.Instance.IncreaseDeathCount();
        }
    }
}
