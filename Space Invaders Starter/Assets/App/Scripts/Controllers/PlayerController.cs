using UnityEngine;

namespace GalaxyDefenders.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 500f;

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
    }
}