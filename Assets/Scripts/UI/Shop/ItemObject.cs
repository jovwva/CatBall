using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ProductStatus
{
    CanBuy,
    CannotBuy,
    Bought,
    Selected
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
        // [SerializeField] private Button          itemButton;
        [SerializeField] private TextMeshProUGUI buttonText;
    
        private Dictionary<ProductStatus, string> statusMessages = new Dictionary<ProductStatus, string>
        {
            { ProductStatus.CanBuy,     "Купить" },
            { ProductStatus.CannotBuy,  "Недоступно" },
            { ProductStatus.Bought,     "Выбрать" },
            { ProductStatus.Selected,   "Выбрано" }
        };
    
        private int id;
    
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
    }
#endregion

#region WorkWithData
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
        priceText.text      = $"{data.Item2}";

        buttonText.text     = GetMessageForStatus(data.Item3);
        gameObject.SetActive(true);
    }

    private string GetMessageForStatus(ProductStatus status)
    {
        if (statusMessages.TryGetValue(status, out string message))
        {
            return message;
        }
        return "потеряшка";
    }
#endregion
}