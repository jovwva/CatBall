using System;
using UnityEngine;

#region Interface
    
    public interface IButtonState
    {
        int id { get; set;}
        void OnButtonClicked();
    }
    public interface IBuyableState
    {
        event EventHandler<int> BuyClicked;
    }
    
    public interface ISelectableState
    {
        event EventHandler<int> SelectClicked;
    }
    
#endregion
public class CanBuyState : IButtonState, IBuyableState
{
    public int id { get; set; }
    public event EventHandler<int> BuyClicked;
    public void OnButtonClicked()
    {
        // Логика для состояния "Можно купить"
        BuyClicked?.Invoke(this, id);
    }
}

public class BoughtState : IButtonState, ISelectableState
{
    public int id { get; set; }
    public event EventHandler<int> SelectClicked;
    public void OnButtonClicked()
    {
        // Логика для состояния "Куплено"
        SelectClicked?.Invoke(this, id);
    }
}

public class SelectedState : IButtonState
{
    public int id { get; set; }

    public void OnButtonClicked()
    {
        // Логика для состояния "Выбрано"
        Debug.Log("Продукт уже выбран!");
    }
}

public class ErrorState : IButtonState
{
    public int id { get; set; }

    public void OnButtonClicked()
    {
        // Логика для состояния "Ошибки"
        Debug.LogWarning($"Вовремя обработки запроса произошла ошибка \nObject id: {id}");
    }
}
