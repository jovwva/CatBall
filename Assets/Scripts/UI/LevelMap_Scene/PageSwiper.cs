using System.Collections.Generic;
using UnityEngine;
public class PageSwiper : MonoBehaviour
{
    private List<Transform> _pages = new List<Transform>();
    private int _currentPageNumber = 0;
    [SerializeField] private int _numberOfPagesTurn = 1;
    
    
    private void Start()
    {
        foreach (Transform page in transform)
        {
            _pages.Add(page);
        }
        
    }
    public void NextPage()
    {
        if(_currentPageNumber < _pages.Count - 1)
        {
            SwipePage(_numberOfPagesTurn);
        }
    }

    public void PreviousPage()
    {
        if(_currentPageNumber > 0)
        {
            SwipePage(- _numberOfPagesTurn);
        }
    }

    private void SwipePage(int i)
    {
        _pages[_currentPageNumber].gameObject.SetActive(false);
        _currentPageNumber += i;
        _pages[_currentPageNumber].gameObject.SetActive(true);
    }

    public ButtonsState CheckButtonsState()
    {
        ButtonsState currentState;
        if (_currentPageNumber == 0)
        {
            currentState = ButtonsState.onlyRight;
        }
        else if (_currentPageNumber == _pages.Count - 1)
        {
            currentState = ButtonsState.onlyLeft;
        }
        else
            currentState = ButtonsState.everyone;
        return currentState;
    }
}
