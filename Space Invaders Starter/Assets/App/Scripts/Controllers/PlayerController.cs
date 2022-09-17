using UnityEngine;
using GalaxyDefenders.Data;

namespace GalaxyDefenders.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] public UpgradeElementsData speed;
        [SerializeField] private Rigidbody2D rb;

        private int speed1 = 500;

#if UNITY_EDITOR
        private void FixedUpdate()
        {
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalInput * speed1, rb.velocity.y);
        }
#endif

#if UNITY_ANDROID
                private void Update()
                {
                    if(Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);

                        if (touch.phase == TouchPhase.Stationary)
                        {
                            if (touch.position.x > screenWidth / 2)
                            {
                                var horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalInput * speed.speed, rb.velocity.y);
                            }
                            if (touch.position.x < screenWidth / 2)
                            {
                                var horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalInput * speed.speed, rb.velocity.y);
                            }
                        }
                    } 
                }
#endif
    }
}