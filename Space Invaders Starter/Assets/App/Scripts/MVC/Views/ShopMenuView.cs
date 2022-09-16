using UnityEngine;
using UnityEngine.UI;

namespace GalaxyDefenders.MVC
{
    public class ShopMenuView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private ShopMenuController controller;

        [Header("View references")]
        [SerializeField] private GameObject view;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject standartItemsScrollView;
        [SerializeField] private GameObject premiumItemsScrollView;
        [SerializeField] private Button standartItems;
        [SerializeField] private Button premiumItems;

        public void Back()
        {
            view.SetActive(false);
            controller.Back();
            mainMenu.SetActive(true);
        }

        public void StandartItems()
        {
            premiumItemsScrollView.SetActive(false);
            premiumItems.interactable=true;
            controller.StandartItems();
            standartItemsScrollView.SetActive(true);
            standartItems.interactable = false;
        }

        public void PremiumItems()
        {
            standartItemsScrollView.SetActive(false);
            standartItems.interactable = true;
            controller.PremiumItems();
            premiumItemsScrollView.SetActive(true);
            premiumItems.interactable = false;
        }
    }
}
