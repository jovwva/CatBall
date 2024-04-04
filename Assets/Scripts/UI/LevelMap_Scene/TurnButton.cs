using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnButton : MonoBehaviour
{

    [SerializeField] private PageSwiper _pageSwiper;
    private int _currentPage;
    private int _maxPage;
    private Button _nexButton;
    private Button _previousButton;
    private void Start()
    {
        _previousButton = gameObject.transform.GetChild(0).GetComponent<Button>();
        _nexButton = gameObject.transform.GetChild(1).GetComponent<Button>();
        CheckButtons();
    }
    public void CheckButtons()
    {
        _pageSwiper.CurrentPageAndMaxPages(out _currentPage,out _maxPage);
        Debug.Log(_currentPage);
        Debug.Log(_maxPage);
        if (_currentPage == _maxPage - 1)
            OffButton(ref _nexButton);
        else
            OnButton(ref _nexButton);
        if (_currentPage == 0)
            OffButton(ref _previousButton);
        else
            OnButton(ref _previousButton);
    }

    private void OffButton(ref Button button)
    {
        button.interactable = false;
    }

    private void OnButton(ref Button button)
    {
        button.interactable = true;
    }
}
