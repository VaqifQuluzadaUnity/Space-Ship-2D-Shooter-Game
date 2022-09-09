using UnityEngine;

namespace GalaxyDefenders.MVC
{
    public class ShopScrollView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private ShopMenuController controller;

        [Header("View references")]
        [SerializeField] private GameObject view;
        [SerializeField] private GameObject mainMenu;

        public void Back()
        {
            view.SetActive(false);
            controller.Back();
            mainMenu.SetActive(true);
        }
    }
}
