using UnityEngine;
using UnityEngine.SceneManagement;

namespace GalaxyDefenders.MVC
{
    public class GameOverView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private GameOverController controller;

        [Header("View references")]
        [SerializeField] private string sceneName;

        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(sceneName);
            controller.Restart();
        }
    }
}
