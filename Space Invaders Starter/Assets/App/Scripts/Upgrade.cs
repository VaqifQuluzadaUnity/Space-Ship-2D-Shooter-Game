using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GalaxyDefenders.Data;
using GalaxyDefenders.Controllers;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private Text upgrade;
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
        if (check.points == int.Parse(upgrade.text))
        {
            var sum = int.Parse(upgrade.text) + increasePrice;
            upgrade.text = sum.ToString();
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
    }
}
