using UnityEngine;

namespace GalaxyDefenders.MVC
{
    public class InstructionsView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private InstructionsController controller;

        [Header("View references")]
        [SerializeField] private GameObject instructionsView;
        [SerializeField] private GameObject mainMenuView;

        public void Back()
        {
            instructionsView.SetActive(false);
            controller.Back();
            mainMenuView.SetActive(true);
        }
    }
}
