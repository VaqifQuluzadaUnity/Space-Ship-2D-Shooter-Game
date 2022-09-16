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

		private LevelData levelState = new LevelData();

		[SerializeField] private int currentLevel;

		List<LevelData> levelStates = new List<LevelData>();

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

				for (int i = 0; i < levelStates.Count; i++)
				{
					if (levelStates[i].isUnlocked == true)
					{
						levelButtons[i].GetComponentInChildren<Image>().gameObject.SetActive(false);
						levelButtons[i].interactable = true;
					}
				}
			}
			else
			{
				for (int i = 0; i < 11; i++)
				{
					levelStates.Add(levelState);
				}

				levelStates[currentLevel].isUnlocked = false;
				levelButtons[currentLevel].GetComponentInChildren<Image>().gameObject.SetActive(false);
				levelButtons[currentLevel].interactable = true;

				LevelData levelData = new LevelData();
				saveManager.SaveToFile<LevelData>(levelData, containerName);
			}
		}

		public void Unlock()
		{
			if (levelStates[currentLevel + 1].isUnlocked == false)
			{
				levelStates[currentLevel + 1].isUnlocked = true;
				levelButtons[currentLevel + 1].GetComponentInChildren<Image>().gameObject.SetActive(false);
				levelButtons[currentLevel + 1].interactable = true;

				LevelData levelData = new LevelData();
				saveManager.SaveToFile<LevelData>(levelData, containerName);
			}
		}
	}
}
