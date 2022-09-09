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
	public class PointsSaveManager : MonoBehaviour
	{
		[SerializeField] private string containerName = "PointsData";

		public int oldPointData;

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
				PointData pointData = saveManager.LoadFromFile<PointData>(containerName, null);

				oldPointData = pointData.points;
			}
		}

		private void OnEnable()
		{
			EventManager.Instance.AddListener<ScoreEvent>(ScoreEventHandler);
		}

		private void OnDisable()
		{
			EventManager.Instance.RemoveListener<ScoreEvent>(ScoreEventHandler);
		}

		#endregion

		private void ScoreEventHandler(ScoreEvent eventDetails)
		{
			int sum = oldPointData + eventDetails.Points;

			PointData newPointData = new PointData(sum);

			Upgrade.Instance.SetCheckPoint(newPointData);

			saveManager.SaveToFile<PointData>(newPointData, containerName);
		}
	}
}
