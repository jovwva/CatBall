using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorAssortment", menuName = "ScriptableObjects/Shop assortment/Color", order = 1)]
public class ColorAssortment : ScriptableObject
{
    public List<ItemColorSO> itemColorSOList = new List<ItemColorSO>();
}
