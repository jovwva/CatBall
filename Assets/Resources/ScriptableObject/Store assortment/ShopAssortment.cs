using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AssortmentOf_", menuName = "ScriptableObjects/ShopItem's/Assortment", order = 3)]
public class ShopAssortment : ScriptableObject
{
    public List<ItemSO> itemList = new List<ItemSO>();
}
