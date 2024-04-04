using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PageSwiper : MonoBehaviour
{
    private List<Transform> _pages = new List<Transform>();
    private int _currentPageNumber = 0;
    private void Awake()
    {
        foreach (Transform page in transform)
        {
            _pages.Add(page);
        }
        Debug.Log(_pages.Count);
    }
    public void NextPage()
    {
        if(_currentPageNumber < _pages.Count - 1)
        {
            Debug.Log(_currentPageNumber);
            _pages[_currentPageNumber].gameObject.SetActive(false);
            _currentPageNumber++;
            _pages[_currentPageNumber].gameObject.SetActive(true);
        }
    }

    public void PreviousPage()
    {
        if(_currentPageNumber > 0)
        {
            Debug.Log(_currentPageNumber);
            _pages[_currentPageNumber].gameObject.SetActive(false);
            _currentPageNumber--;
            _pages[_currentPageNumber].gameObject.SetActive(true);
        }
    }

    // Возвращает текущую страницу и максимальное кол-во страниц
    public void CurrentPageAndMaxPages(out int curPage, out int maxPage)
    {
        curPage = _currentPageNumber;
        maxPage = _pages.Count;
    }
}
