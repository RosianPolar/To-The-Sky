using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopKeeperDisplay : MonoBehaviour
{
    // [SerializeField] private ShopSlotUI _shopSlot;
    [SerializeField] private shoppingCartItemUI _shopCartItem;


    [SerializeField] private Button _selectItem;

    [Header("Shopping Cart")]

    [SerializeField] private TextMeshProUGUI _basketTotalText;
    [SerializeField] private TextMeshProUGUI _CoinsText;
    [SerializeField] private Button _buyItem;

    [SerializeField] private GameObject _itemListContentPanel;
    [SerializeField] private GameObject _shopCartListContentPanel;
}

