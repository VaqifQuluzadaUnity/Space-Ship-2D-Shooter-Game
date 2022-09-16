using UnityEngine;
using DynamicBox.EventManagement;
using DynamicBox.SaveManagement;
using GalaxyDefenders.MVC;
using GalaxyDefenders.Data;

namespace GalaxyDefenders.Managers
{
    public class UpgradeElementsDataSaveManager : MonoBehaviour
    {
        [SerializeField] private string containerName = "UpgradeElementsData";

        private UpgradeElementsData upgradeElementsData = new UpgradeElementsData(500, 0.5f);

        SaveManager saveManager;

        private int addSpeed = 25;
        private float removeCoolDownTime = -0.1f;

        #region Unity Methods

        private void Awake()
        {
            saveManager = new SaveManager(StorageMethod.JSON);
        }

        void Start()
        {
            if(saveManager.FileExists(containerName))
            {
                UpgradeElementsData oldUpgradeElementsData = saveManager.LoadFromFile<UpgradeElementsData>(containerName, null);
            }
            else
            {
                UpgradeElementsData newUpgradeElementsData = new UpgradeElementsData(500, 0.5f);

                saveManager.SaveToFile<UpgradeElementsData>(newUpgradeElementsData, containerName);
            }
        }

        private void OnEnable()
        {
            EventManager.Instance.AddListener<UpgradeEvent>(UpgradeEventHandler);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<UpgradeEvent>(UpgradeEventHandler);
        }
        #endregion

        private void UpgradeEventHandler(UpgradeEvent eventdetails)
        {
            if(eventdetails.number==1)
            {
                upgradeElementsData.speed += addSpeed;

                UpgradeElementsData newUpgradeElementsData = new UpgradeElementsData(upgradeElementsData.speed, upgradeElementsData.coolDownTime);

                saveManager.SaveToFile<UpgradeElementsData>(newUpgradeElementsData, containerName);
            }
            else if(eventdetails.number==2)
            {
                upgradeElementsData.coolDownTime += removeCoolDownTime;

                UpgradeElementsData newUpgradeElementsData = new UpgradeElementsData(upgradeElementsData.speed, upgradeElementsData.coolDownTime);

                saveManager.SaveToFile<UpgradeElementsData>(newUpgradeElementsData, containerName);
            }
        }
    }
}
