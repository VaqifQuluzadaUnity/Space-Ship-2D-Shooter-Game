using UnityEngine;

namespace GalaxyDefenders.MVC
{
    public class MainMenuView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private MainMenuController controller;

        [Header("View references")]
        [SerializeField] private GameObject view;
        [SerializeField] private GameObject ui;
        [SerializeField] private GameObject instructions;
        [SerializeField] private GameObject options;
        [SerializeField] private GameObject levels;
        [SerializeField] private GameObject shopMenu;

        void Start()
        {
            Time.timeScale = 0;
        }

        public void Play()
        {
            view.SetActive(false);
            controller.Play();
            Time.timeScale = 1;
            ui.SetActive(true);
        }

        public void Instructions()
        {
            view.SetActive(false);
            controller.Instructions();
            instructions.SetActive(true);
        }

        public void Options()
        {
            view.SetActive(false);
            controller.Options();
            options.SetActive(true);
        }

        public void Levels()
        {
            view.SetActive(false);
            controller.Levels();
            levels.SetActive(true);
        }

        public void ShopMenu()
        {
            view.SetActive(false);
            controller.Instructions();
            shopMenu.SetActive(true);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
