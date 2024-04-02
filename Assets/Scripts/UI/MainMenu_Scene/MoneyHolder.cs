using System;
using TMPro;
using UnityEngine;

public class MoneyHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyValueText;

    private void Start()
    {
        moneyValueText.text = $"{SaveSystem.Instance.GetMoneyValue()}";
    }
}
