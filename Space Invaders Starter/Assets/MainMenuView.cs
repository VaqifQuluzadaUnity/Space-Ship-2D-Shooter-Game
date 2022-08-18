using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuView : MonoBehaviour
{
    [Header("Controller reference")]
    [SerializeField] private MainMenuController controller;

    [Header("View references")]
    [SerializeField] private GameObject panelEntrance;

    /*
    void Start()
    {
        Time.timeScale = 0;
    }

    
    public void Play()
    {
        panelEntrance.SetActive(false);

        Time.timeScale = 1;

    }
  */
}
