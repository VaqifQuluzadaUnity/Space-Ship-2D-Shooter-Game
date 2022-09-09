using UnityEngine;
using DynamicBox.EventManagement;
using UnityEngine.UI;

namespace GalaxyDefenders.MVC
{
    public class AllClearView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private AllClearController controller;

		//[Header("View references")]

		/*private void OnEnable()
		{
			EventManager.Instance.AddListener<Event>(EventHandler);
		}

		private void OnDisable()
		{
			EventManager.Instance.RemoveListener<Event>(EventHandler);
		}*/

	}
}
