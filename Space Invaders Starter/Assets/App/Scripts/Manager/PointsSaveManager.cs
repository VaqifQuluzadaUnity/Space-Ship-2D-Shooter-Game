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
		public int sum;

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
			EventManager.Instance.AddListener<PurchaseEvent>(PurchaseEventHandler);
		}

		private void OnDisable()
		{
			EventManager.Instance.RemoveListener<ScoreEvent>(ScoreEventHandler);
			EventManager.Instance.RemoveListener<PurchaseEvent>(PurchaseEventHandler);
		}

		#endregion

		private void ScoreEventHandler(ScoreEvent eventDetails)
		{
			sum = oldPointData + eventDetails.Points;

			PointData newPointData = new PointData(sum);

			Upgrade.Instance.SetCheckPoint(newPointData);

			saveManager.SaveToFile<PointData>(newPointData, containerName);
		}

		private void PurchaseEventHandler(PurchaseEvent eventDetails)
        {
			sum-= int.Parse(Upgrade.Instance.price.text);

			PointData pointDataAfterPurchase = new PointData(sum);

			Upgrade.Instance.SetCheckPoint(pointDataAfterPurchase);

			saveManager.SaveToFile<PointData>(pointDataAfterPurchase, containerName);

		}
	}
}
