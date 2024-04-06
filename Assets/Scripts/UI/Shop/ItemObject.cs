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
        public bool isTestRun = false;

        public Sprite        testIcon;
        public string        testPrice;
        public ProductStatus testStatus;
        
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
    
        // private Data data;
    
#endregion

    private void Start()
    {
        if (isTestRun)
        {
            Tuple<Sprite, string, ProductStatus> dataTest = 
                new Tuple<Sprite, string, ProductStatus>(testIcon, testPrice, testStatus);
            SetData<object>(dataTest);
        }
    }
#region WorkWithData
    public void TurnOff()
    {
        gameObject.SetActive(false);
        // data = null;
    }

    public void SetData<T>(Tuple<Sprite, string, ProductStatus> data)
    {
        iconImage.sprite    = data.Item1;
        priceText.text      = data.Item2;

        buttonText.text     = GetMessageForStatus(data.Item3);
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