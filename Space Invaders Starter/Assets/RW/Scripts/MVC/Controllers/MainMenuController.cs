using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class MainMenuController : MonoBehaviour
{
	[SerializeField] private MainMenuView view;

	/*private void OnEnable()
	{
		//EventManager.Instance.AddListener<Event>(EventHandler);
	}


	private void OnDisable()
	{
		//EventManager.Instance.RemoveListener<Event>(EventHandler);

	}*/

	public void Play()
	{
		EventManager.Instance.Raise(new PlayEvent());
	}

	public void Instructions()
	{
		EventManager.Instance.Raise(new InstructionsEvent());
	}

	public void Options()
	{
		EventManager.Instance.Raise(new OptionsEvent());
	}

	public void Levels()
	{
		EventManager.Instance.Raise(new LevelsEvent());
	}
}
