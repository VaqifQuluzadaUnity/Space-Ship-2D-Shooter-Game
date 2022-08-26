using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DynamicBox.EventManagement;
using DynamicBox.SaveManagement;

public class UIDataSaver : MonoBehaviour
{
    [SerializeField] private string containerName = "UIData";

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
			UIData oldUIData = saveManager.LoadFromFile<UIData>(containerName, null);

			EventManager.Instance.Raise(new UIDataExistedEvent(uiData));
		}
	}

	private void OnEnable()
	{
		EventManager.Instance.AddListener<UIDataEvent>(UIDataEventHandler);
	}

	private void OnDisable()
	{
		EventManager.Instance.RemoveListener<UIDataEvent>(UIDataEventHandler);
	}

	#endregion

	private void UIDataEventHandler(UIDataEvent eventDetails)
	{
		UIData newUIData = new UIData(eventDetails.bestScore);

		saveManager.SaveToFile<UIData>(newUIData, containerName);
	}
}
