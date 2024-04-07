using UnityEngine.UI;
public enum ButtonsState
{
    Everyone,
    Right,
    Left,
    Nothing
}
public class MapButtonVisualizer
{
    private Button leftButton;
    private Button rightButton;

    private ButtonsState state = ButtonsState.Everyone;
    
    public MapButtonVisualizer(Button leftButton, Button rightButton)
    {
        this.leftButton  = leftButton;
        this.rightButton = rightButton;
    }

    public void SwitchState(ButtonsState newState)
    {
        if (state == newState)
            return;  

        leftButton.interactable = newState != ButtonsState.Right;
        rightButton.interactable = newState != ButtonsState.Left;
        
        state = newState;
    }
}
