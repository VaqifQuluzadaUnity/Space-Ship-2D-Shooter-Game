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
        [SerializeField] public List<GameObject> spawnedMeteors = new List<GameObject>();

        public int randomMeteor;
        private int randomSpawnPoint;

        GameObject meteor;

        IEnumerator SpawnMeteors()
        {
            for (int i = 0; i < 6; i++)
            {
                randomMeteor = Random.Range(0, meteors.Length);
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                meteor = Instantiate(meteors[randomMeteor], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
                spawnedMeteors.Add(meteor);
                //Destroy(meteor, 5f);
                yield return new WaitForSeconds(3f);
            }
        }

        private void Start()
        {
            StartCoroutine(SpawnMeteors());
        }

        private void Update()
        {
            foreach (GameObject meteor in spawnedMeteors)
            {
                meteor.transform.Translate(speed * Time.deltaTime * Vector2.down);
                Destroy(meteor, 5f);
            }
        }

        private void OnCollisionEnter2D(Collision2D otherCollider)
        {
            if (otherCollider.gameObject.CompareTag("Hero"))
            {
                Destroy(gameObject);
                SFX_Controller.Instance.CreateExplosion(transform.position);
            }
        }
    }
}
