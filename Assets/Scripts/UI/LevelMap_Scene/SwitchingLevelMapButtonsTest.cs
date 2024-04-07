public enum ButtonsStateTest
{
    everyone,
    onlyRight,
    onlyLeft,
    nothing
}

public class SwitchingLevelMapButtonsTest
{
    ButtonsState state = ButtonsState.nothing;
    public PageSwiper pageSwiper;
    public SwitchingLevelMapButtonsTest()
    {
        state = pageSwiper.CheckButtonsState();
        switch (state)
        {
            case ButtonsState.everyone:
                
                break;
            case ButtonsState.onlyRight:
                
                break;
            case ButtonsState.onlyLeft:
                
                break;
            case ButtonsState.nothing:
                
                break;
        }
    }
}
