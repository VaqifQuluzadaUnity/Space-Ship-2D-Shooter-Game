using UnityEngine;

namespace GalaxyDefenders.MVC
{
    public class GameOverView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private GameOverController controller;

        //[Header("View references")]

        public void Restart()
        {
            //Load Scene
            controller.Restart();
        }
    }
}
