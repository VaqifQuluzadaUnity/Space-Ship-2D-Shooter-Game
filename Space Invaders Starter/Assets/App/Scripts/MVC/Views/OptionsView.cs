using UnityEngine;
using UnityEngine.UI;

namespace GalaxyDefenders.MVC
{
    public class OptionsView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private OptionsController controller;

        [Header("View references")]
        [SerializeField] private GameObject optionsView;
        [SerializeField] private GameObject mainMenuView;

        public Sprite soundOnImage;
        public Sprite soundOffImage;
        public Image image1;
        public Image image2;
        private bool isOn = true;
        public AudioSource audioSource;

        public void Mute()
        {
            if (isOn)
            {
                image1.sprite = soundOffImage;
                image2.sprite = soundOffImage;
                isOn = false;
                audioSource.mute = true;
            }
            else
            {
                image1.sprite = soundOnImage;
                image2.sprite = soundOnImage;
                isOn = true;
                audioSource.mute = false;
            }
            controller.Mute();
        }

        public void Back()
        {
            optionsView.SetActive(false);
            controller.Back();
            mainMenuView.SetActive(true);
        }
    }
}
