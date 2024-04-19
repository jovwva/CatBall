using TMPro;
using UnityEngine;

public class MoneyHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyValueText;

    private void Start()
    {
        UpdateMoney();

        AssortmentBroker.MoneyChnaged += UpdateMoney;
    }
    void OnDestroy()
    {
        AssortmentBroker.MoneyChnaged -= UpdateMoney;
    }

    private void UpdateMoney() => moneyValueText.text = SaveSystem.Instance.GetMoneyValue().ToString();
}
