using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "ScriptableObjects/New Shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public enum CurrencyType
    {
        Stars,
        Jewels,
        Lives,
        IAP
    }
    public CurrencyType currencyType;
    public string title;
    public int amount;
}
