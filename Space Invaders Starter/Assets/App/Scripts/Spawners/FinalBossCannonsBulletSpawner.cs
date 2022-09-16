using UnityEngine;
using GalaxyDefenders.Music_SFX;

namespace GalaxyDefenders.Spawners
{
    public class FinalBossCannonsBulletSpawner : MonoBehaviour
    {
        [SerializeField] private AudioClip shooting;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float minTime;
        [SerializeField] private float maxTime;
        [SerializeField] private Transform muzzle1;
        [SerializeField] private Transform muzzle2;

        private float timer;
        private float currentTime;

        internal void Setup()
        {
            timer = Random.Range(minTime, maxTime);
            currentTime = 0f;

            Instantiate(bulletPrefab, muzzle1.position, Quaternion.identity);
            Instantiate(bulletPrefab, muzzle2.position, Quaternion.identity);
            SFX_Controller.Instance.PlaySfx(shooting);
        }

        private void Update()
        {
            currentTime += Time.deltaTime;
            if (currentTime > timer)
            {
                Setup();
            }
        }

    }
}
