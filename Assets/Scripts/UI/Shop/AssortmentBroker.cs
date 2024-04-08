using System;
using UnityEngine;

public class AssortmentBroker : MonoBehaviour
{
#region Field

    [Header("Тестовые данные")]
    [SerializeField] private bool isTestRun = false;

    [SerializeField] private ItemColorSO  testColorItem;
    [SerializeField] private ItemShapeSO  testShapeItem;
    [SerializeField] private ItemSO       testAnyItem;

    public static event Action  ColorChanged;
    public static event Action  ShapeChanged;
    public static event Action  MoneyChnaged;
    
#endregion

#region MonoBehaviour
    
    private void Start()
    {
        if (isTestRun)
        {
            SelectColor(testColorItem.id);
            SelectShape(testShapeItem.id);
            
            TryBuyItem(testAnyItem);
        }
    }
    private void OnDisable()
    {
        SaveSystem.Instance.SaveProgress();
    }
        
#endregion
    
#region Event

    public bool TryBuyItem(ItemSO item)
    {
        if (!SaveSystem.Instance.TrySetMoneyValue(-item.price)) 
            return false;

        MoneyChnaged?.Invoke();    

        SaveSystem.Instance.SetItemData(new ItemData(item.id, ProductStatus.Bought));
        return true;
    }

    public void DeselectItem(int id)
    {
        SaveSystem.Instance.SetItemData(new ItemData(id, ProductStatus.Bought));
    }
    public void SelectColor(int id)
    {
        SaveSystem.Instance.SetBackColor(id);
        ColorChanged?.Invoke();

        SaveSystem.Instance.SetItemData(new ItemData(id, ProductStatus.Selected));
    }
    public void SelectShape(int id)
    {
        SaveSystem.Instance.SetBackShape(id);
        ShapeChanged?.Invoke();

        SaveSystem.Instance.SetItemData(new ItemData(id, ProductStatus.Selected));
    }

#endregion
}
