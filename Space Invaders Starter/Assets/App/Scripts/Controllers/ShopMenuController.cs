using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GalaxyDefenders.Data;
using GalaxyDefenders.Managers;

namespace GalaxyDefenders.Controllers
{
    public class ShopMenuController : MonoBehaviour
    {
        public static ShopMenuController instance;

        [SerializeField] private GameObject shopItemButtonPrefab;
        [SerializeField] private GameObject premiumItemButtonPrefab;
        [SerializeField] private Transform standartItemsContentParent;
        [SerializeField] private Transform premiumItemsContentParent;
        [SerializeField] private ShopItemSO[] standartItemsArray;
        [SerializeField] private ShopItemSO[] premiumItemsArray;
        [SerializeField] private ShipButtonController currentSelectedShip;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(instance);
            }
            instance = this;
        }

        private void Start()
        {
            FetchDataFromStorage();

            SetStandartItems();
        }

        private void FetchDataFromStorage()
        {
            ShipItemsData shipItemsData = new ShipItemsData();

            if (SaveManagerSingleton.instance.saveManager.FileExists(SaveManagerSingleton.instance.shipsJsonFileName))
            {
                shipItemsData =
                SaveManagerSingleton.instance.saveManager.LoadFromFile<ShipItemsData>
                (
                       SaveManagerSingleton.instance.shipsJsonFileName, new ShipItemsData()
                );
            }
            else
            {
                SaveManagerSingleton.instance.saveManager.SaveToFile<ShipItemsData>
                (
                    shipItemsData, SaveManagerSingleton.instance.shipsJsonFileName
                );
            }

            if (shipItemsData.shipStates.Count == 0)
            {
                foreach (ShopItemSO shipDataRef in standartItemsArray)
                {
                    shipItemsData.shipStates.Add(shipDataRef.shipState);
                }

                foreach (ShopItemSO shipDataRef in premiumItemsArray)
                {
                    shipItemsData.shipStates.Add(shipDataRef.shipState);
                }

                SaveManagerSingleton.instance.saveManager.SaveToFile<ShipItemsData>
                (
                    shipItemsData, SaveManagerSingleton.instance.shipsJsonFileName

                );
            }
            SetDataToShips(shipItemsData.shipStates);
        }

        private void SetDataToShips(List<ShipState> shipStates)
        {
            for (int i = 0; i < standartItemsArray.Length; i++)
            {
                standartItemsArray[i].shipState = shipStates[i];
            }

            for (int i = 0; i < premiumItemsArray.Length; i++)
            {
                premiumItemsArray[i].shipState = shipStates[i];
            }
        }

        private void SetStandartItems()
        {
            for (int i = 0; i < standartItemsArray.Length; i++)
            {
                GameObject buttonInstance = Instantiate(shopItemButtonPrefab, standartItemsContentParent);

                ShipButtonController buttonController = buttonInstance.GetComponent<ShipButtonController>();

                buttonController.SetShipData(standartItemsArray[i]);
                buttonController.SetupShipDataOnUI();
            }
            for (int i = 0; i < premiumItemsArray.Length; i++)
            {
                GameObject buttonInstance = Instantiate(premiumItemButtonPrefab, premiumItemsContentParent);

                ShipButtonController buttonController = buttonInstance.GetComponent<ShipButtonController>();

                buttonController.SetShipData(premiumItemsArray[i]);
                buttonController.SetupShipDataOnUI();
            }
        }

        public void SetCurrentSelectedShip(ShipButtonController shipButtonCont)
        {
            if (currentSelectedShip != null)
            {
                currentSelectedShip.DeselectItem();
            }
            currentSelectedShip = shipButtonCont;
        }

        private void OnApplicationQuit()
        {
            ShipItemsData shipItemsData = new ShipItemsData();

            foreach (ShopItemSO shipData in standartItemsArray)
            {
                shipItemsData.shipStates.Add(shipData.shipState);
            }

            foreach (ShopItemSO shipData in premiumItemsArray)
            {
                shipItemsData.shipStates.Add(shipData.shipState);
            }

            SaveManagerSingleton.instance.saveManager.SaveToFile<ShipItemsData>
            (
                shipItemsData, SaveManagerSingleton.instance.shipsJsonFileName

            );
        }
    }
}
