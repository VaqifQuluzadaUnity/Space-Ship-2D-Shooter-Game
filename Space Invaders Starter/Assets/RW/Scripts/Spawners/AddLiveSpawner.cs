using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyDefenders
{
    public class AddLiveSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject live;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private float speed = 200f;
        [SerializeField] private float lifeTime = 5f;

        private int randomSpawnPoint;

        IEnumerator SpawnLives()
        {
            for (int i = 0; i < 6; i++)
            {
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                Instantiate(live, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
                yield return new WaitForSeconds(3f);
            }
        }

        internal void DestroySelf()
        {
            Destroy(live);
        }

        private void Awake()
        {
            Invoke("DestroySelf", lifeTime);
        }

        private void Start()
        {
            StartCoroutine(SpawnLives());
        }

        private void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector2.down);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            DestroySelf();
            GameManager.Instance.AddLives();
        }
    }
}
