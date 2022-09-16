using UnityEngine;
using UnityEngine.Purchasing;
using GalaxyDefenders.Controllers;

public class IAPShop : MonoBehaviour
{
    [SerializeField] ShipButtonController controller;

    public void OnPurchaseComplete(Product product)
    {
        controller.BuyOrSelectShip();
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {

    }
}
