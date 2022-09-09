using UnityEngine;
using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private GameOverView view;

        /*private void OnEnable()
		{
			//EventManager.Instance.AddListener<Event>(EventHandler);
		}


		private void OnDisable()
		{
			//EventManager.Instance.RemoveListener<Event>(EventHandler);

		}*/

        public void Restart()
        {

        }
    }
}
