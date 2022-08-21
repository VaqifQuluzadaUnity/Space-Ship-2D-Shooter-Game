using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class OptionsController : MonoBehaviour
{
	[SerializeField] private OptionsView view;

	/*private void OnEnable()
	{
		//EventManager.Instance.AddListener<Event>(EventHandler);
	}


	private void OnDisable()
	{
		//EventManager.Instance.RemoveListener<Event>(EventHandler);

	}*/

	public void Mute()
	{
		EventManager.Instance.Raise(new MuteEvent());
	}

	public void Back()
	{
		EventManager.Instance.Raise(new BackEvent());
	}
}
