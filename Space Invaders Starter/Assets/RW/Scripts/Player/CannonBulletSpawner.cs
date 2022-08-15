using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyDefenders
{
    public class CannonBulletSpawner : MonoBehaviour
    {
        [SerializeField] private float coolDownTime = 0.5f;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform muzzle;
        [SerializeField] private AudioClip shooting;

        private float shootTimer;

        void Update()
        {
            shootTimer += Time.deltaTime;

            if (shootTimer > coolDownTime)
            {
                shootTimer = 0f;

                Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
                SFX_Controller.Instance.PlaySfx(shooting);
            }
        }
    }
}