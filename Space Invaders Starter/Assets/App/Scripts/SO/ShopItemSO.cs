using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GalaxyDefenders.Data;

[CreateAssetMenu(fileName = "NewShopItem", menuName = "ScriptableObjects/NewShopItemData")]

public class ShopItemSO : ScriptableObject
{
    [Header("References")]
    [SerializeField] private Sprite itemSprite;

    [Header("Properties")]
    [SerializeField] private string itemName;
    //[SerializeField] private int itemPrice;

    public ShipState shipState;

    public Sprite ReturnItemSprite()
    {
        return itemSprite;
    }

    public string ReturnItemName()
    {
        return itemName;
    }

    /*public int ReturnItemPrice()
    {
        return itemPrice;
    }*/

    public void BuyItem()
    {
        shipState.isBuy = true;
    }

    public bool GetIsBuy()
    {
        return shipState.isBuy;
    }

    public void SelectItem()
    {
        shipState.isSelect = true;
    }

    public void DeselectItem()
    {
        shipState.isSelect = false;
    }

    public bool GetIsSelect()
    {
        return shipState.isSelect;
    }
}
