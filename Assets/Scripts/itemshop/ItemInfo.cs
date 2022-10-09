using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceText;
    public Text QuantityText;
    public GameObject ShopManager;


    void Update()
    {
     PriceText.text = "Price: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString() + " coins";
     QuantityText.text = "You own: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString();

    }
}