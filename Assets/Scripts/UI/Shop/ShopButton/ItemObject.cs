using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ProductStatus
{
    CanBuy,
    Bought,
    Selected,
    Error,
}

public class ItemObject : MonoBehaviour
{
#region Field
    [Header("Тестовые данные")]
    [SerializeField] private bool isTestRun = false;

    [SerializeField] private ItemSO        testItem;
    [SerializeField] private ProductStatus testStatus = ProductStatus.Bought;
    
    [Space]
    [Header("Elements")]
    [SerializeField] private Image           iconImage;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button          itemButton;
    [SerializeField] private TextMeshProUGUI buttonText;

    private Dictionary<ProductStatus, ButtonStateInfo> statusInfo;

    private int id;
    private IButtonState currentState;
    
#endregion

#region MonoBehaviour
    private void Awake()
    {
        if (!isTestRun)
            TurnOff();
    }
    private void Start()
    {
        if (isTestRun)
        {
            Tuple<Sprite, int, ProductStatus, int> dataTest = 
                new Tuple<Sprite, int, ProductStatus, int>(testItem.icon, testItem.price, testStatus, testItem.id);
            SetData<object>(dataTest);
        }

        itemButton.onClick.AddListener(OnButtonClicked);
    }
#endregion

    private void OnButtonClicked()
    {
        currentState.OnButtonClicked();
    }

    private void SetButtonState(ProductStatus status)
    {
        if (statusInfo.ContainsKey(status))
        {
            ButtonStateInfo stateInfo = statusInfo[status];
            
            buttonText.text = stateInfo.message;
            currentState    = stateInfo.state;
        }
        else
        {
            ButtonStateInfo stateInfo = statusInfo[ProductStatus.Error];

            itemButton.interactable = false;
            buttonText.text = stateInfo.message;
            currentState    = stateInfo.state;
        }
    }

#region WorkWithData

    public void InitielizeButton(ShopBroker broker)
    {
        statusInfo = new Dictionary<ProductStatus, ButtonStateInfo>
        {
            { ProductStatus.CanBuy,     new ButtonStateInfo("Купить", new CanBuyState()) },
            { ProductStatus.Bought,     new ButtonStateInfo("Выбрать", new BoughtState()) },
            { ProductStatus.Selected,   new ButtonStateInfo("Выбрано", new SelectedState()) },
            { ProductStatus.Error,      new ButtonStateInfo("Недоступно", new ErrorState()) },
        };

        foreach (var kvp in statusInfo)
        {
            if (kvp.Value.state is IBuyableState buyableState)
            {
                buyableState.BuyClicked += (sender, id) => broker.TryBuy(id);
            }

            if (kvp.Value.state is ISelectableState selectableState)
            {
                selectableState.SelectClicked += (sender, id) => broker.TrySelect(id);
            }
        }
    }
    public void TurnOff()
    {
        gameObject.SetActive(false);
        id = -1;
    }

    public void SetData<T>(Tuple<Sprite, int, ProductStatus, int> data)
    {
        if (id == data.Item4) return;
        
        id = data.Item4;
        iconImage.sprite    = data.Item1;   
        priceText.text      = data.Item2.ToString();

        SetButtonState(data.Item3);

        gameObject.SetActive(true);
    }
#endregion
}