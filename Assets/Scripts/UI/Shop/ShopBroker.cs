using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBroker : MonoBehaviour
{
#region Field
    [Header("Тестовые данные")]
    [SerializeField] private bool isTestRun = false;

    [SerializeField] private ShopAssortment  testAssortment;
    [SerializeField] private ProductStatus   testStatus = ProductStatus.Bought;

    [Space]
    [Header("Списки")]
    [SerializeField] private List<ItemObject> itemList;
    [SerializeField] private ShopAssortment  colorAssortment;
    [SerializeField] private ShopAssortment  shapeAssortment;
    [Space]
    [Header("Кнопки")]
    [SerializeField] private Button colorPanelButton;
    [SerializeField] private Button shapePanelButton;

    private ShopState shopState = ShopState.Empty;
    private Dictionary<ShopState, ShopAssortment> statusMessages;
#endregion

#region MonoBehaviour
    
    private void Awake()
    {
        statusMessages = new Dictionary<ShopState, ShopAssortment>
        {
            { ShopState.ColorPanel, colorAssortment },
            { ShopState.ShapePanel, shapeAssortment },
        };

        colorPanelButton.onClick.AddListener(() => ChangeActivePanel(ShopState.ColorPanel));
        shapePanelButton.onClick.AddListener(() => ChangeActivePanel(ShopState.ShapePanel));
    }
    private void Start()
    {
        ChangeActivePanel(ShopState.ColorPanel);
    }
        
#endregion

#region WorkWithData
    private void ChangeActivePanel(ShopState shopState)
    {
        if (this.shopState == shopState) return;
        
        ResetAssortment();

        if (isTestRun)
        {
            SetAssortment(testAssortment.itemList);
            return;
        }

        ShopAssortment data = GetAssortment(shopState);
        if (data == null)
        {
            Debug.LogWarning("Ассортимент не найден!");
            return;
        }

        SetAssortment(data.itemList);
    }
    private void ResetAssortment()
    {
        foreach(ItemObject item in itemList)
            item.TurnOff();
    }
    private void SetAssortment(List<ItemSO> dataList)
    {
        if (isTestRun)
        {
            for (int i = 0; i < testAssortment.itemList.Count; i++)
            {
                Tuple<Sprite, int, ProductStatus, int> value = new Tuple<Sprite, int, ProductStatus, int>(
                    testAssortment.itemList[i].icon, testAssortment.itemList[i].price, testStatus, testAssortment.itemList[i].id);
                        
                itemList[i].SetData<object>(value);
            }
            return;
        }

        for (int i = 0; i < dataList.Count; i++)
        {
            ProductStatus status = SaveSystem.Instance.GetItemData(dataList[i].id).itemState;

            Tuple<Sprite, int, ProductStatus, int> value = new Tuple<Sprite, int, ProductStatus, int>
                (dataList[i].icon, dataList[i].price, status, dataList[i].id);
            itemList[i].SetData<object>(value);
        }
    }
    private ShopAssortment GetAssortment(ShopState AssortmentType)
    {
        if (statusMessages.TryGetValue(AssortmentType, out ShopAssortment data))
        {
            return data;
        }
        return null;
    }
#endregion
}

[Serializable]
public enum ShopState
{
    Empty,
    ColorPanel,
    ShapePanel,
}