using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBroker : MonoBehaviour
{
#region Field
    [Header("Тестовые данные")]
    public bool isTestRun = false;

    public Sprite testIcon;
    public string testPrice;
    public ProductStatus testStatus;

    [Space]
    [Header("Объекты")]
    [SerializeField] private List<ItemObject> itemList;
    [Space]
    [Header("Кнопки")]
    [SerializeField] private Button colorPanelButton;
    [SerializeField] private Button shapePanelButton;

    private ShopState shopState;
#endregion

#region MonoBehaviour
    
    private void Start()
    {
        shopState = ShopState.ColorPanel;

        colorPanelButton.onClick.AddListener(() => ChangeActivePanel(ShopState.ColorPanel));
        shapePanelButton.onClick.AddListener(() => ChangeActivePanel(ShopState.ShapePanel));
        
        if (isTestRun)
        {
            List<int> i = new List<int>();
            SetAssortment(i);
        }
    }
        
#endregion

#region WorkWithData
    private void ChangeActivePanel(ShopState shopState)
    {
        if (this.shopState == shopState) return;
        
        Debug.Log(shopState);
        ResetAssortment();

        // SetAssortment();
    }
    private void ResetAssortment()
    {
        foreach(ItemObject item in itemList)
            item.TurnOff();
    }
    private void SetAssortment<T>(List<T> data)
    {
        foreach(ItemObject item in itemList)
        {
            Tuple<Sprite, string, ProductStatus> dataTest = 
                new Tuple<Sprite, string, ProductStatus>(testIcon, testPrice, testStatus);
            item.SetData<object>(dataTest);
        }
    }
#endregion
}

[System.Serializable]
public enum ShopState
{
    ColorPanel,
    ShapePanel,
}