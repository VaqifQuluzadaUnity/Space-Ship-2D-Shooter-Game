using UnityEngine;
using GalaxyDefenders.Music_SFX;
using DynamicBox.EventManagement;

namespace GalaxyDefenders.Controllers
{
    public class FinalBossController : MonoBehaviour
    {
        [SerializeField] private float speedFactor;
        [SerializeField] private MusicControl musicControl;

        private float minX;
        private float currentY;
        private float currentX;
        private float xIncrement;
        private float maxX;
        private bool checkPosition=true;

        void Start()
        {
            minX = gameObject.transform.position.x;
            currentY = gameObject.transform.position.y;
            currentX = gameObject.transform.position.x;
            maxX = 100;
        }

        void Update()
        {
            xIncrement = speedFactor * musicControl.Tempo * Time.deltaTime;
            if (checkPosition)
            {
                currentX += xIncrement;
                if (currentX < maxX)
                {
                    gameObject.transform.Translate(-xIncrement, 0, 0);
                }
                else
                {
                    checkPosition = !checkPosition;
                    gameObject.transform.Translate(0, 25, 0);
                    currentY -= 25;
                    if (currentY < -170)
                    {
                        EventManager.Instance.Raise(new TriggerGameOverEvent(true));
                    }
                }
            }
            else
            {
                currentX -= xIncrement;
                if (currentX > minX)
                {
                    gameObject.transform.Translate(xIncrement, 0, 0);
                }
                else
                {
                    checkPosition = !checkPosition;
                    gameObject.transform.Translate(0, 25, 0);
                    currentY -= 25;
                    if (currentY < -170)
                    {
                        EventManager.Instance.Raise(new TriggerGameOverEvent(true));
                    }
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.GetComponent<Bullet>())
            {
                return;
            }
            EventManager.Instance.Raise(new FinalBossEvent(-1));
        }
    }
}
