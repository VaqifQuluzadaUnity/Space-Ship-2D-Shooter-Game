using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DynamicBox.EventManagement;
using DynamicBox.SaveManagement;
using GalaxyDefenders.MVC;

public class LevelsDataSaveManager : MonoBehaviour
{
	[SerializeField] private string containerName = "LevelsData";

	[SerializeField] private Image image;
	[SerializeField] private Button nextLevel;

	SaveManager saveManager;

	#region Unity Methods

	private void Awake()
	{
		saveManager = new SaveManager(StorageMethod.JSON);
	}

	private void Start()
	{
		if (saveManager.FileExists(containerName))
		{
			EventManager.Instance.Raise(new LevelDataEvent());
		}
	}

	private void OnEnable()
	{
		EventManager.Instance.AddListener<NextLevelEvent>(NextLevelEventHandler);
	}

	private void OnDisable()
	{
		EventManager.Instance.RemoveListener<NextLevelEvent>(NextLevelEventHandler);
	}

	#endregion

	private void NextLevelEventHandler(NextLevelEvent eventDetails)
	{
		image.gameObject.SetActive(false);
		nextLevel.interactable=true;

		saveManager.SaveToFile<LevelData>(null, containerName);
	}
}
