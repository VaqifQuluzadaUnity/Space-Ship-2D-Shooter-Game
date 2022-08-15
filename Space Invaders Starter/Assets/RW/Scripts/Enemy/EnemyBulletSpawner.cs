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

        internal void Setup()
        {
            currentTime = Random.Range(minTime, maxTime);

            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //SFX_Controller.Instance.PlaySfx(shooting);
        }

        private void Update()
        {
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

    }
}