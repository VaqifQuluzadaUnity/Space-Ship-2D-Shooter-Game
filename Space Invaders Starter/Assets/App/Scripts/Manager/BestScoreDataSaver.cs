using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DynamicBox.EventManagement;
using DynamicBox.SaveManagement;
using GalaxyDefenders.MVC;
using GalaxyDefenders.Data;

namespace GalaxyDefenders.Managers
{
	public class BestScoreDataSaver : MonoBehaviour
	{
		[SerializeField] private string containerName = "BestScoreData";

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
				BestScoreData oldBestScoreData = saveManager.LoadFromFile<BestScoreData>(containerName, null);

				EventManager.Instance.Raise(new BestScoreDataExistedEvent(oldBestScoreData));
			}
		}

		private void OnEnable()
		{
			EventManager.Instance.AddListener<BestScoreDataEvent>(BestScoreDataEventHandler);
		}

		private void OnDisable()
		{
			EventManager.Instance.RemoveListener<BestScoreDataEvent>(BestScoreDataEventHandler);
		}

		#endregion

		private void BestScoreDataEventHandler(BestScoreDataEvent eventDetails)
		{
			BestScoreData newBestScoreData = new BestScoreData(eventDetails.bestScore);

			saveManager.SaveToFile<BestScoreData>(newBestScoreData, containerName);
		}
	}
}
