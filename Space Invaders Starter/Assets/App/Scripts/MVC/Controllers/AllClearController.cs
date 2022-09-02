using UnityEngine;
using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
	public class AllClearController : MonoBehaviour
	{
		[SerializeField] private AllClearView view;

		public void NextLevel()
        {
			EventManager.Instance.Raise(new NextLevelEvent());
		}
	}
}
