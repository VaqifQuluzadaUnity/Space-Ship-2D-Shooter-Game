using UnityEngine;

namespace GalaxyDefenders
{
    public class EnemyBulletSpawner : MonoBehaviour
    {
        [SerializeField] private AudioClip shooting;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float minTime;
        [SerializeField] private float maxTime;

        private float timer;
        private float currentTime;
        private GameObject followTarget;

        internal void Setup()
        {
            currentTime = Random.Range(minTime, maxTime);

            foreach (GameObject enemy in InvaderSwarm.Instance.spawnedEnemies)
            {
                followTarget = enemy;
                Instantiate(bulletPrefab, enemy.transform.position, Quaternion.identity);
                SFX_Controller.Instance.PlaySfx(shooting);
            }
        }

        private void Update()
        {
            transform.position = followTarget.transform.position;

            timer += Time.deltaTime;
            if (timer < currentTime)
            {
                return;
            }
            else
            {
                Setup();
            }
            timer = 0f;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.GetComponent<Bullet>())
            {
                return;
            }

            GameManager.Instance.UpdateScore(InvaderSwarm.Instance.GetPoints());
            InvaderSwarm.Instance.IncreaseDeathCount();
            followTarget.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }

    }
}