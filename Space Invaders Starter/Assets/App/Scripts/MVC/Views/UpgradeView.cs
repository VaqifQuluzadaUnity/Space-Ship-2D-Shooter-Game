using UnityEngine;
using UnityEngine.UI;
using GalaxyDefenders.Data;
using GalaxyDefenders.Controllers;
using DynamicBox.EventManagement;
using GalaxyDefenders.Spawners;

namespace GalaxyDefenders.MVC
{
    public class UpgradeView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private UpgradeController controller;

        [Header("View references")]
        [SerializeField] private GameObject view;
        [SerializeField] private GameObject menu;
        [SerializeField] public Text movementPrice;
        [SerializeField] public Text bulletPrice;
        [SerializeField] private Text bank;
        [SerializeField] private PointData check;
        [SerializeField] private PricesData pricesData;

        private int increasePrice = 150;

        public void UpgradeMovement()
        {
            if (check.points >= int.Parse(movementPrice.text))
            {
                controller.UpgradeMovement();
                var sum = int.Parse(movementPrice.text) + increasePrice;
                EventManager.Instance.Raise(new PricesEvent(sum, int.Parse(bulletPrice.text)));
                movementPrice.text = sum.ToString();
            }
        }

        public void UpgradeBullet()
        {
            if (check.points >= int.Parse(bulletPrice.text))
            {
                controller.UpgradeBullet();
                var sum = int.Parse(bulletPrice.text) + increasePrice;
                EventManager.Instance.Raise(new PricesEvent(int.Parse(movementPrice.text), sum));
                bulletPrice.text = sum.ToString();
            }
        }

        private void Start()
        {
            movementPrice.text = pricesData.movementPrice.ToString();
            bulletPrice.text = pricesData.bulletPrice.ToString();
            bank.text = $"Points: {check.points.ToString()}";
        }

        public void Back()
        {
            view.SetActive(false);
            controller.Back();
            menu.SetActive(true);
        }
    }
}
