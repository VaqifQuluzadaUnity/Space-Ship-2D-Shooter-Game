using UnityEngine;
using GalaxyDefenders.Spawners;
using GalaxyDefenders.Music_SFX;

namespace GalaxyDefenders.Controllers
{
    public class MeteorController : MonoBehaviour
    {
        [SerializeField] private float speed = 100f;

        private void Update()
        {
            gameObject.transform.Translate(speed * Time.deltaTime * Vector2.down);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.GetComponent<Bullet>())
            {
                gameObject.SetActive(false);
                MeteorSpawner.Instance.meteorPool.Push(gameObject);
            }
        }
    }
}
