using UnityEngine;
using UnityEngine.UI;
public enum ButtonsState
{
    Everyone,
    Right,
    Left,
    Nothing
}
public class SwitcherLevelMapButtons: MonoBehaviour
{
    [Header("Кнопки")]
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [Space]
    [Header("Данные")]
    [SerializeField] ButtonsState state = ButtonsState.Everyone;

    public void SwitchState(ButtonsState newState)
    {
        if (state == newState)
            return;  

        switch (newState)
        {
            case ButtonsState.Everyone:
                leftButton.interactable = true;
                rightButton.interactable = true;
                break;
            case ButtonsState.Right:
                leftButton.interactable = false;
                rightButton.interactable = true;
                break;
            case ButtonsState.Left:
                leftButton.interactable = true;
                rightButton.interactable = false;
                break;
            default:
                leftButton.interactable = false;
                rightButton.interactable = false;
                break;
        }
        state = newState;
    }
}
