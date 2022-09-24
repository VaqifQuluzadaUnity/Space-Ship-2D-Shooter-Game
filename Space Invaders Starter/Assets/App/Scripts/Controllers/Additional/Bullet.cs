using UnityEngine;
using GalaxyDefenders.Music_SFX;

namespace GalaxyDefenders
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 200f;
        [SerializeField] private float lifeTime = 5f;
        [SerializeField] private Rigidbody2D rb;

        internal void DestroySelf()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        private void Awake()
        {
            Invoke("DestroySelf", lifeTime);
        }

        private void Update()
        {
            rb.velocity = new Vector2(rb.velocity.x,speed * MusicControl.Instance.Tempo);
            //transform.Translate(speed * MusicControl.Instance.Tempo * Time.deltaTime * Vector2.up);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            DestroySelf();
            SFX_Controller.Instance.CreateExplosion(transform.position);
        }
    }
}
