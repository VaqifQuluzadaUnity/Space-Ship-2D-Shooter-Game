using UnityEngine;
using GalaxyDefenders.Music_SFX;

namespace GalaxyDefenders.Spawners
{
    public class EnemyBulletSpawner : MonoBehaviour
    {
        [SerializeField] private AudioClip shooting;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float minTime;
        [SerializeField] private float maxTime;

        private float timer;
        private float currentTime;
        private Vector3 bulletPosition = new Vector3(0, 20, 0);

        internal void Setup()
        {
            currentTime = Random.Range(minTime, maxTime);

            Instantiate(bulletPrefab, transform.position-bulletPosition, Quaternion.identity);
            SFX_Controller.Instance.PlaySfx(shooting);
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