using UnityEngine;

namespace GalaxyDefenders
{
    public class CannonControl : MonoBehaviour
    {
        [SerializeField]
        private float speed = 500f;

        [SerializeField]
        private Transform muzzle;

        [SerializeField]
        private AudioClip shooting;

        [SerializeField]
        private float coolDownTime = 0.5f;

        [SerializeField]
        private Bullet bulletPrefab;

        private float shootTimer;

        [SerializeField]
        private float respawnTime = 2f;

        [SerializeField]
        private SpriteRenderer sprite;

        [SerializeField]
        private Collider2D cannonCollider;

        private Vector2 startPos;

        private void Start() => startPos = transform.position;

//#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }

            shootTimer += Time.deltaTime;

            if (shootTimer > coolDownTime)
            {
                shootTimer = 0f;

                Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
                GameManager.Instance.PlaySfx(shooting);
            }
        }
//#endif

/*#if UNITY_ANDROID
        private void Update()
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Stationary)
                {
                    if (touch.position.x > screenWidth / 2)
                    {
                        transform.Translate(speed * Time.deltaTime, 0, 0);
                    }
                    if (touch.position.x < screenWidth / 2)
                    {
                        transform.Translate(-speed * Time.deltaTime, 0, 0);
                    }
                }
            } 
            
            shootTimer += Time.deltaTime;

            if (shootTimer > coolDownTime)
            {
                shootTimer = 0f;

                Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
                GameManager.Instance.PlaySfx(shooting);
            }
        }
#endif
*/
        private void OnCollisionEnter2D(Collision2D other)
        {
            GameManager.Instance.UpdateLives();
            StopAllCoroutines();
            StartCoroutine(Respawn());
        }

        System.Collections.IEnumerator Respawn()
        {
            enabled = false;
            cannonCollider.enabled = false;
            ChangeSpriteAlpha(0.0f);

            yield return new WaitForSeconds(0.25f * respawnTime);

            transform.position = startPos;
            enabled = true;
            ChangeSpriteAlpha(0.25f);

            yield return new WaitForSeconds(0.75f * respawnTime);

            ChangeSpriteAlpha(1.0f);
            cannonCollider.enabled = true;
        }

        private void ChangeSpriteAlpha(float value)
        {
            var color = sprite.color;
            color.a = value;
            sprite.color = color;
        }
    }
}