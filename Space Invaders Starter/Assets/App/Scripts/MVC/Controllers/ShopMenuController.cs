using UnityEngine;
using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class ShopMenuController : MonoBehaviour
    {
        [SerializeField] private ShopScrollView view;

		/*private void OnEnable()
		{
			//EventManager.Instance.AddListener<Event>(EventHandler);
		}


		private void OnDisable()
		{
			//EventManager.Instance.RemoveListener<Event>(EventHandler);

		}*/

		public void Back()
		{
			EventManager.Instance.Raise(new BackEvent());
		}
	}
}
