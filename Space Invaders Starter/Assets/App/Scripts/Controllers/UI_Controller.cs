using UnityEngine;

namespace GalaxyDefenders.Controllers
{
    public class UI_Controller : MonoBehaviour
    {
        internal static UI_Controller Instance;

        private int points = 0;

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

        internal int GetPoints()
        {
            points++;
            return points;
        }
    }
}
