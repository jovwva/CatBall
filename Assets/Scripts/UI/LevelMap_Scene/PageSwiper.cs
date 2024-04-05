using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PageSwiper : MonoBehaviour
{
    private List<Transform> _pages = new List<Transform>();
    private int _currentPageNumber = 0;
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
            SwipePage(1);
        }
        else
        {
            SwipePage(- _currentPageNumber);
        }
    }

    public void PreviousPage()
    {
        if(_currentPageNumber > 0)
        {
            SwipePage(-1);
        }
        else
        {
            SwipePage(_pages.Count - 1);
        }
    }

    private void SwipePage(int numberOfPages)
    {
        _pages[_currentPageNumber].gameObject.SetActive(false);
        _currentPageNumber += numberOfPages;
        _pages[_currentPageNumber].gameObject.SetActive(true);
    }
}
