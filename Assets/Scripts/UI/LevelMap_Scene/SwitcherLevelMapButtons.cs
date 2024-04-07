using UnityEngine;
using UnityEngine.UI;
public enum ButtonsState
{
    everyone,
    onlyRight,
    onlyLeft,
    nothing
}
public class SwitcherLevelMapButtons: MonoBehaviour
{
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _nextButton;
    [SerializeField] private PageSwiper pageSwiper;
    ButtonsState state = ButtonsState.everyone;
    private void Start()
    {
        SwitchState();
    }
    public void SwitchState()
    {
        if (state == pageSwiper.CheckButtonsState())
            return;  
        state = pageSwiper.CheckButtonsState();
        switch (state)
        {
            case ButtonsState.everyone:
                _previousButton.interactable = true;
                _nextButton.interactable = true;
                break;
            case ButtonsState.onlyRight:
                _previousButton.interactable = false;
                _nextButton.interactable = true;
                break;
            case ButtonsState.onlyLeft:
                _previousButton.interactable = true;
                _nextButton.interactable = false;
                break;
            case ButtonsState.nothing:
                _previousButton.interactable = false;
                _nextButton.interactable = false;
                break;
        }
    }
}
