using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GalaxyDefenders.Music_SFX;
using GalaxyDefenders.Data;

namespace GalaxyDefenders.Spawners
{
    public class PlayerBulletSpawner : MonoBehaviour
    {
        [SerializeField] UpgradeElementsData coolDownTime;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform muzzle;
        [SerializeField] private AudioClip shooting;

        private float shootTimer;

        void Update()
        {
            shootTimer += Time.deltaTime;

            if (shootTimer > coolDownTime.coolDownTime)
            {
                shootTimer = 0f;

                Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
                SFX_Controller.Instance.PlaySfx(shooting);
            }
        }
    }
}