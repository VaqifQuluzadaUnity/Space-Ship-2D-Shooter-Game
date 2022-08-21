using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsView : MonoBehaviour
{
    [Header("Controller reference")]
    [SerializeField] private OptionsController controller;

    [Header("View references")]
    [SerializeField] private GameObject optionsView;
    [SerializeField] private GameObject mainMenuView;

    public Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button1;
    public Button button2;
    private bool isOn = true;
    public AudioSource audioSource;

    public void Mute()
    {
        if (isOn)
        {
            button1.image.sprite = soundOffImage;
            button2.image.sprite = soundOffImage;
            isOn = false;
            audioSource.mute = true;
        }
        else
        {
            button1.image.sprite = soundOnImage;
            button2.image.sprite = soundOnImage;
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
