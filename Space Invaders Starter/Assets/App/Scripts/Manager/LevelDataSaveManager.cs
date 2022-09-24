using DynamicBox.SaveManagement;
using GalaxyDefenders.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GalaxyDefenders.Managers
{
    public class LevelDataSaveManager : MonoBehaviour
    {
        [SerializeField] private string containerName = "LevelsData";

        [SerializeField] private Button[] levelButtons;

        SaveManager saveManager;

        private int currentLevel;

        private void Awake()
        {
            saveManager = new SaveManager(StorageMethod.JSON);

            currentLevel = SceneManager.GetActiveScene().buildIndex;
        }

        private void Start()
        {
            if (saveManager.FileExists(containerName))
            {
                LevelData levelData = saveManager.LoadFromFile<LevelData>(containerName, null);

                for (int i = 0; i < levelButtons.Length; i++)
                {
                    if (levelData.levelStates[i].isUnlocked == true)
                    {
                        levelButtons[i].GetComponentInChildren<Image>().gameObject.SetActive(false);
                        levelButtons[i].interactable = true;
                    }
                }
            }
            else
            {
                LevelData levelData = new LevelData(levelButtons.Length);

                foreach (LevelStates levelState in levelData.levelStates)
                {
                    for (int i = 0; i < levelButtons.Length; i++)
                    {
                        levelData.levelStates[i]=levelState;
                    }
                }

                levelData.levelStates[currentLevel].isUnlocked = true;
                levelButtons[currentLevel].GetComponentInChildren<Image>().gameObject.SetActive(false);
                levelButtons[currentLevel].interactable = true;

                saveManager.SaveToFile<LevelData>(levelData, containerName);
            }
        }

        public void Unlock()
        {
            LevelData levelData = new LevelData(levelButtons.Length);

            SceneManager.LoadScene(currentLevel + 1);

            if (levelData.levelStates[currentLevel + 1].isUnlocked == false)
            {
                levelData.levelStates[currentLevel + 1].isUnlocked = true;
                levelButtons[currentLevel + 1].GetComponentInChildren<Image>().gameObject.SetActive(false);
                levelButtons[currentLevel + 1].interactable = true;

                saveManager.SaveToFile<LevelData>(levelData, containerName);
            }
        }
    }
}
