using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GalaxyDefenders
{
    public class MeteorSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] meteors;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private float speed = 200f;
        [SerializeField] private float lifeTime = 5f;

        public int randomMeteor;
        private int randomSpawnPoint;

        IEnumerator SpawnMeteors()
        {
            for (int i=0;i<6;i++)
            {
                randomMeteor = Random.Range(0, meteors.Length);
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                Instantiate(meteors[randomMeteor], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
                yield return new WaitForSeconds(3f);
            }
        }

        internal void DestroySelf()
        {
            Destroy(meteors[randomMeteor]);
        }

        private void Awake()
        {
            Invoke("DestroySelf", lifeTime);
        }

        private void Start()
        {
            StartCoroutine(SpawnMeteors());
        }

        private void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector2.down);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            DestroySelf();
            GameManager.Instance.CreateExplosion(transform.position);
        }
    }
}
