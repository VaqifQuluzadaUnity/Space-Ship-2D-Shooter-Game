using UnityEngine;

namespace GalaxyDefenders.MVC
{
    public class UIView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private UIController controller;

        //[Header("View references")]

        internal static UIView Instance;

        private int points = 0;
        private int bestPoints = 0;

        public void GetPoints()
        {
            points++;
            controller.UI(points,bestPoints);
        }

        public void GetBestPoints()
        {
            if (bestPoints < points)
            {
                bestPoints = points;
                controller.UI(points,bestPoints);
            }
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
