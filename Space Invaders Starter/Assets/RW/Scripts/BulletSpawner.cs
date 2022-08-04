using UnityEngine;

namespace GalaxyDefenders
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField]
        private AudioClip shooting;

        [SerializeField]
        private GameObject bulletPrefab;

        [SerializeField]
        private Transform spawnPoint;

        [SerializeField]
        private float minTime;

        [SerializeField]
        private float maxTime;

        private float timer;
        private float currentTime;
        private GameObject followTarget;

        internal void Setup()
        {
            currentTime = Random.Range(minTime, maxTime);
            followTarget = InvaderSwarm.Instance.enemyPrefabs[InvaderSwarm.Instance.randomEnemy];
        }

        private void Update()
        {
            transform.position = followTarget.transform.position;

            timer += Time.deltaTime;
            if (timer < currentTime)
            {
                return;
            }

            Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            GameManager.Instance.PlaySfx(shooting);
            timer = 0f;
            currentTime = Random.Range(minTime, maxTime);
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.GetComponent<Bullet>())
            {
                return;
            }

            GameManager.Instance.
                UpdateScore(InvaderSwarm.Instance.GetPoints());

            InvaderSwarm.Instance.IncreaseDeathCount();

            followTarget.GetComponentInChildren<SpriteRenderer>().enabled = false;

            Setup();
        }

    }
}