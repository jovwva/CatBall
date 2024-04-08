public struct ButtonStateInfo
{
    public string message;
    public IButtonState state;

    public ButtonStateInfo(string message, IButtonState state)
    {
        this.message = message;
        this.state = state;
    }
}
