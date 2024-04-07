using System.Collections.Generic;
using UnityEngine;

public class PageSwiper : MonoBehaviour
{
    [SerializeField] private SwiperType swiperType = SwiperType.Loop;
    [SerializeField] private List<Transform> _pages = new List<Transform>();
    [SerializeField] private SwitcherLevelMapButtons sw;

    private int _currentPageNumber = 0;

    private void Start()
    {
        UpdateButton();
    }

    public void StepRight()
    {
        SwipePage(1);
    }

    public void StepLeft()
    {
        SwipePage(-1);
    }

    private void SwipePage(int i)
    {
        if (swiperType == SwiperType.Limited)
        {
            CountPages(i);
            UpdateButton();
        }
        else
        {
            if(_currentPageNumber == 0 && i < 0)
            {
                CountPages(_pages.Count - 1);
            }
            else if (_currentPageNumber == _pages.Count - 1 && i > 0)
            {
                CountPages(-(_pages.Count - 1));
            }
            else
            {
                CountPages(i);
            }
            UpdateButton();
        }
    }

    private void CountPages(int i)
    {
        _pages[_currentPageNumber].gameObject.SetActive(false);
        _currentPageNumber += i;
        _pages[_currentPageNumber].gameObject.SetActive(true);
    }

    private void UpdateButton()
    {
        if (swiperType == SwiperType.Limited)
        {
            if (_currentPageNumber == 0)
                sw.SwitchState(ButtonsState.Right);
            else if(_currentPageNumber == _pages.Count - 1)
                sw.SwitchState(ButtonsState.Left);
            else
                sw.SwitchState(ButtonsState.Everyone);
        }   
        else
        {
            sw.SwitchState(ButtonsState.Everyone);
        }
    }
}

[System.Serializable]
public enum SwiperType
{
    Loop,
    Limited
}