using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageSwiper : MonoBehaviour
{
    [SerializeField] private SwiperType swiperType = SwiperType.Loop;
    [SerializeField] private List<Transform> pageList = new List<Transform>();
    [Header("Кнопки")]
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private MapButtonVisualizer ButtonVisualizer;

    private int _currentPageNumber = 0;

    private void Start()
    {
        ButtonVisualizer = new MapButtonVisualizer(leftButton, rightButton);
        
        UpdateButton();
    }  

    public void StepRight() => SwipePage(1);
    public void StepLeft()  => SwipePage(-1);

    private void SwipePage(int delta)
    {
        EventBusHolder.Instance.EventBus.Raise(new ButtonClick( ButtonType.ActionButton ));
        if(swiperType == SwiperType.Loop)
        {
            if(_currentPageNumber == 0 && delta < 0)
            {
                CountPages(pageList.Count -1);
                return;
            }
            else if (_currentPageNumber == pageList.Count - 1 && delta > 0)
            {
                CountPages(-(pageList.Count - 1));
                return;
            }
        }
        CountPages(delta);
    }

    private void CountPages(int i)
    {
        pageList[_currentPageNumber].gameObject.SetActive(false);
        _currentPageNumber += i;
        pageList[_currentPageNumber].gameObject.SetActive(true);

        UpdateButton();
    }

    private void UpdateButton()
    {
        if (swiperType == SwiperType.Limited)
        {
            if (_currentPageNumber == 0)
                ButtonVisualizer.SwitchState(ButtonsState.Right);
            else if(_currentPageNumber == pageList.Count - 1)
                ButtonVisualizer.SwitchState(ButtonsState.Left);
            else
                ButtonVisualizer.SwitchState(ButtonsState.Everyone);
        }   
        else
        {
            ButtonVisualizer.SwitchState(ButtonsState.Everyone);
        }
    }
}

[System.Serializable]
public enum SwiperType
{
    Loop,
    Limited
}