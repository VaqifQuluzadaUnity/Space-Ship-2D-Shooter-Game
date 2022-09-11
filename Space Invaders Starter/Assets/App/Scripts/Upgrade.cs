using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GalaxyDefenders.Data;
using GalaxyDefenders.Controllers;
using DynamicBox.EventManagement;
using GalaxyDefenders.MVC;

public class Upgrade : MonoBehaviour
{
    [SerializeField] public Text price;
    [SerializeField] private Text bank;
    [SerializeField] private PointData check;
    [SerializeField] private PlayerController speed;

    internal static Upgrade Instance;

    private int addSpeed = 25;
    private int increasePrice = 150;

    public void SetCheckPoint(PointData checkPoint)
    {
        check = checkPoint;
    }

    public void UpgradeMovement()
    {
        if (check.points == int.Parse(price.text))
        {
            EventManager.Instance.Raise(new PurchaseEvent());
            var sum = int.Parse(price.text) + increasePrice;
            price.text = sum.ToString();
            speed.speed+=addSpeed;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        bank.text = $"Points: {check.points.ToString()}";
    }
}
