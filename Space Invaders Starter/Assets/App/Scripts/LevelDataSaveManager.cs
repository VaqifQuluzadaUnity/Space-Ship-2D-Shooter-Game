using DynamicBox.SaveManagement;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataSaveManager : MonoBehaviour
{
	[SerializeField] private string containerName = "LevelsData";

	[SerializeField] private GameObject[] levelButtons;

	SaveManager saveManager;

	public LevelState levelState;

	public int currentLevel;

	private void Awake()
	{
		saveManager = new SaveManager(StorageMethod.JSON);
	}

	private void Start()
	{
		if (saveManager.FileExists(containerName))
		{
			LevelData levelData = saveManager.LoadFromFile<LevelData>(containerName, null);
		}
		/*else
		{
			List<LevelState> levelStates = new List<LevelState>();

			for (int i = 0; i < 11; i++)
			{
				levelStates.Add(levelStates);
			}
		}*/
	}

	/*private void Unlock()
	{
		if (levelState[currentLevel + 1].lock)
			{
				levelState[currentLevel + 1].lock= false;
				levelButtons[currentLevel + 1].image = false;
				levelButtons[currentLevel + 1].interactible = true;

				LevelData levelData = new LevelData();
				saveManager.SaveToFile<LevelData>(levelData, containerName);
			}
	}*/
}



[System.Serializable]

public class LevelState
{
	public bool isUnlocked;
}