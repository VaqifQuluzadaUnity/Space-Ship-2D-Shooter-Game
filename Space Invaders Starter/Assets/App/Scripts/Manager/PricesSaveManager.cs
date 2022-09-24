using UnityEngine;
using DynamicBox.EventManagement;
using DynamicBox.SaveManagement;
using GalaxyDefenders.MVC;
using GalaxyDefenders.Data;

namespace GalaxyDefenders.Managers
{
    public class PricesSaveManager : MonoBehaviour
    {
        [SerializeField] private string containerName = "PricesData";

        SaveManager saveManager;

        #region Unity Methods

        private void Awake()
        {
            saveManager = new SaveManager(StorageMethod.JSON);
        }

        void Start()
        {
            if (saveManager.FileExists(containerName))
            {
                PricesData pricesData = saveManager.LoadFromFile<PricesData>(containerName, null);

                EventManager.Instance.Raise(new PricesDataFetchEvent(pricesData));
            }
            else
            {
                PricesData newPricesData = new PricesData(150, 150);

                EventManager.Instance.Raise(new PricesDataFetchEvent(newPricesData));

                saveManager.SaveToFile<PricesData>(newPricesData, containerName);
            }
        }

        private void OnEnable()
        {
            EventManager.Instance.AddListener<PricesEvent>(PricesEventHandler);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<PricesEvent>(PricesEventHandler);
        }
        #endregion

        private void PricesEventHandler(PricesEvent eventdetails)
        {
            PricesData newPricesData = new PricesData(eventdetails.movementPrice, eventdetails.bulletPrice);

            EventManager.Instance.Raise(new PricesDataFetchEvent(newPricesData));

            saveManager.SaveToFile<PricesData>(newPricesData, containerName);
        }
    }
}
