using UnityEngine;

namespace GalaxyDefenders.MVC
{
    public class CreditsView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private CreditsController controller;

        [Header("View references")]
        [SerializeField] private GameObject view;
        [SerializeField] private GameObject menu;

        public void Back()
        {
            view.SetActive(false);
            controller.Back();
            menu.SetActive(true);
        }
    }
}
