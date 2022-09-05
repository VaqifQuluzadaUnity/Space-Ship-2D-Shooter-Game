using UnityEngine;
using DynamicBox.EventManagement;
using UnityEngine.UI;

namespace GalaxyDefenders.MVC
{
    public class AllClearView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private AllClearController controller;

		[Header("View references")]
		[SerializeField] private Image image;
		[SerializeField] private Button nextLevel;

		public void NextLevel()
        {
            controller.NextLevel();
        }

		private void OnEnable()
		{
			EventManager.Instance.AddListener<LevelDataEvent>(LevelDataEventHandler);
		}

		private void OnDisable()
		{
			EventManager.Instance.RemoveListener<LevelDataEvent>(LevelDataEventHandler);
		}

		private void LevelDataEventHandler(LevelDataEvent eventDetails)
		{
			image.SetActive(false);
			nextLevel.IsInteractible(true);
		}
	}
}
