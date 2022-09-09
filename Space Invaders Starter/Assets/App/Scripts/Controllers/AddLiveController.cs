using UnityEngine;
using GalaxyDefenders.Spawners;

namespace GalaxyDefenders.Controllers
{
    public class AddLiveController : MonoBehaviour
    {
        [SerializeField] private float speed = 100f;

        private void Update()
        {
            gameObject.transform.Translate(speed * Time.deltaTime * Vector2.down);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.GetComponent<PlayerController>())
            {
                gameObject.SetActive(false);
                AddLiveSpawner.Instance.addLivePool.Push(gameObject);
            }
        }
    }
}