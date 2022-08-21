using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class PauseController : MonoBehaviour
{
	[SerializeField] private PauseView view;

	/*private void OnEnable()
	{
		//EventManager.Instance.AddListener<Event>(EventHandler);
	}


	private void OnDisable()
	{
		//EventManager.Instance.RemoveListener<Event>(EventHandler);

	}*/

	public void Pause()
	{
		EventManager.Instance.Raise(new PauseEvent());
	}

	public void Resume()
	{
		EventManager.Instance.Raise(new ResumeEvent());
	}

	public void MainMenu()
	{
		EventManager.Instance.Raise(new MainMenuEvent());
	}
}
