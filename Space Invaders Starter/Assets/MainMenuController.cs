using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class MainMenuController : MonoBehaviour
{
	[SerializeField] private MainMenuView view;

	private void OnEnable()
	{
		//EventManager.Instance.AddListener<Event>(EventHandler);
	}


	private void OnDisable()
	{
		//EventManager.Instance.RemoveListener<Event>(EventHandler);

	}

	public void EventHandler(Event eventDetails)
	{
		
	}
}
