using System;
using UnityEngine;
using UnityEngine.UI;
using DynamicBox.EventManagement;
using GalaxyDefenders.Spawners;

namespace GalaxyDefenders.Controllers
{
    public class ShipButtonController : MonoBehaviour
    {
        [SerializeField] Image shipIconImage;
        //[SerializeField] private Text shipPriceText;
        [SerializeField] private Button buyOrSelectButton;
        [SerializeField] private Text buyOrSelectButtonText;
        [SerializeField] ShopItemSO shipData;

        public void SetupShipDataOnUI()
        {
            shipIconImage.sprite = shipData.ReturnItemSprite();

            //shipPriceText.text = shipData.ReturnItemPrice().ToString();

            if (shipData.shipState.isBuy)
            {
                if (shipData.shipState.isSelect)
                {
                    SelectItem();
                }
                else
                {
                    DeselectItem();
                }
            }
        }

        public void SetShipData(ShopItemSO _shipData)
        {
            shipData = _shipData;
        }
        
        public void BuyOrSelectShip()
        {
            if (shipData.GetIsBuy())
            {
                if (!shipData.GetIsSelect())
                {
                    SelectItem();
                }
            }
            else
            {
                //Currency check
                shipData.BuyItem();
                SelectItem();
            }
        }

        private void SelectItem()
        {
            ShopMenuController.instance.SetCurrentSelectedShip(this);

            shipData.SelectItem();

            buyOrSelectButton.interactable = false;
            buyOrSelectButtonText.text = "Selected";

            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerRespawn>().SetShipData(shipData);
            EventManager.Instance.Raise(new ChangePlayerShipEvent());
        }

        public void DeselectItem()
        {
            shipData.DeselectItem();
            buyOrSelectButton.interactable = true;
            buyOrSelectButtonText.text = "Select";
        }
    }
}
