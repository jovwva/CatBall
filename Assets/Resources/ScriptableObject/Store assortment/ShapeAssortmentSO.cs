using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShapeAssortment", menuName = "ScriptableObjects/Shop assortment/Shape", order = 2)]
public class ShapeAssortmentSO : ScriptableObject
{
    public List<ItemShapeSO> itemShapeSOList = new List<ItemShapeSO>();
}
