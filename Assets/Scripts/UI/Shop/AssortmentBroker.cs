using System;
using UnityEngine;

public class AssortmentBroker : MonoBehaviour
{
    [Header("Тестовые данные")]
    [SerializeField] private bool isTestRun = false;

    [SerializeField] private ItemColorSO  testColorItem;
    [SerializeField] private ItemShapeSO  testShapeItem;
    [SerializeField] private ItemSO       testAnyItem;

    public static event Action  ColorChanged;
    public static event Action  ShapeChanged;
    public static event Action  MoneyChnaged;

    private void Start()
    {
        if (isTestRun)
        {
            ChangeSelectedColor(testColorItem.id);
            ChangeSelectedShape(testShapeItem.id);
            
            TryBuyItem(testAnyItem);
        }
    }

    public void TryBuyItem(ItemSO item)
    {
        if (!SaveSystem.Instance.TrySetMoneyValue(-item.price)) return;

        MoneyChnaged?.Invoke();    

        if (isTestRun) return;    
        SaveSystem.Instance.SetItemData(new ItemData(item.id, ProductStatus.Bought));
    }
    public void ChangeSelectedColor(int id)
    {
        SaveSystem.Instance.SetBackColor(id);
        ColorChanged?.Invoke();

        if (isTestRun) return;
        SaveSystem.Instance.SetItemData(new ItemData(id, ProductStatus.Selected));
    }
    public void ChangeSelectedShape(int id)
    {
        SaveSystem.Instance.SetBackShape(id);
        ShapeChanged?.Invoke();

        if (isTestRun) return;
        SaveSystem.Instance.SetItemData(new ItemData(id, ProductStatus.Selected));
    }
}
