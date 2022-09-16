using UnityEngine;

namespace GalaxyDefenders.MVC
{
    public class AllClearView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private AllClearController controller;

		[Header("View references")]
		[SerializeField] private GameObject view;
		[SerializeField] private GameObject menu;

		public void MainMenu()
        {
            view.SetActive(false);
            controller.MainMenu();
            menu.SetActive(true);
        }

	}
}
