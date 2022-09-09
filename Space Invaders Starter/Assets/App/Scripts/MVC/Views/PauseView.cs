using UnityEngine;
using UnityEngine.UI;

namespace GalaxyDefenders.MVC
{
    public class PauseView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private PauseController controller;

        [Header("View references")]
        [SerializeField] private GameObject pauseView;
        [SerializeField] private GameObject mainMenuView;

        public void Pause()
        {
            Time.timeScale = 0;
            pauseView.SetActive(true);
            controller.Pause();
        }

        public void Resume()
        {
            Time.timeScale = 1;
            pauseView.SetActive(false);
            controller.Resume();
        }

        public void MainMenu()
        {
            pauseView.SetActive(false);
            mainMenuView.SetActive(true);
            controller.MainMenu();
        }
    }
}
