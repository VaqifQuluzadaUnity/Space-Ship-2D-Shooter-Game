using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyDefenders
{
    public class MeteorSpawner : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] sprites;

        [SerializeField]
        private Transform[] spawnPoints;

        [SerializeField]
        private float speed = 200f;

        //[SerializeField]
        //private float lifeTime = 5f;

        internal void DestroySelf()
        {
            //gameObject.SetActive(false);
            //Destroy(sprites);
        }

        private void Awake()
        {
            //Invoke("DestroySelf", lifeTime);
        }

        private void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector2.down);

            Instantiate(sprites[Random.Range(1, 20)], spawnPoints[Random.Range(1, 43)].position, Quaternion.identity);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            //DestroySelf();
            GameManager.Instance.CreateExplosion(transform.position);
        }
    }
}
