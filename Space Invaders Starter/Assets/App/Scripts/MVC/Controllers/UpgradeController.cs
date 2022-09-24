using UnityEngine;
using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class UpgradeController : MonoBehaviour
    {
        [SerializeField] private UpgradeView view;

        public void UpgradeMovement()
        {
            EventManager.Instance.Raise(new PurchaseEvent(1));
            EventManager.Instance.Raise(new UpgradeEvent(1));
        }

        public void UpgradeBullet()
        {
            EventManager.Instance.Raise(new PurchaseEvent(2));
            EventManager.Instance.Raise(new UpgradeEvent(2));
        }

        private void OnEnable()
        {
            EventManager.Instance.AddListener<PricesDataFetchEvent>(PricesDataFetchEventHandler);
            EventManager.Instance.AddListener<CheckFetchEvent>(CheckFetchEventHandler);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<PricesDataFetchEvent>(PricesDataFetchEventHandler);
            EventManager.Instance.RemoveListener<CheckFetchEvent>(CheckFetchEventHandler);
        }

        private void PricesDataFetchEventHandler(PricesDataFetchEvent eventDetails)
        {
            view.pricesData = eventDetails.PricesData;
            view.movementPrice.text = view.pricesData.movementPrice.ToString();
            view.bulletPrice.text = view.pricesData.bulletPrice.ToString();
        }

        private void CheckFetchEventHandler(CheckFetchEvent eventDetails)
        {
            view.check = eventDetails.PointData;
            view.bank.text = $"Points: {view.check.points.ToString()}";
        }

        public void Back()
        {

        }
    }
}
