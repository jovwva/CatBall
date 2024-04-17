using UnityEngine;

public readonly struct BallDestroyedEvent : IEvent {
public readonly BallType BallType;

public BallDestroyedEvent(BallType ballType) {
    BallType = ballType;
}
}
public readonly struct BallApprovedEvent : IEvent {
    public readonly BallType BallType;

    public BallApprovedEvent(BallType ballType) {
        BallType = ballType;
    }
}

public readonly struct PipeEmptiedEvent : IEvent {
    public readonly GameObject PipeObject;

    public PipeEmptiedEvent(GameObject pipeObject) {
        PipeObject = pipeObject;
    }
}

public readonly struct ToolDrag : IEvent {
    public readonly GameState gameState;

    public ToolDrag(GameState gameState) {
        this.gameState = gameState;
    }
}

public readonly struct ButtonClick : IEvent {
    public readonly ButtonType buttonState;

    public ButtonClick(ButtonType buttonState) {
        this.buttonState = buttonState;
    }
}

[System.Serializable]
public enum GameState {
    Normal,
    Slow,
    Pause,
}
[System.Serializable]
public enum ButtonType
{
    CloseButton,
    OpenButton,
    ActionButton,
    CoinTransferButton,
}

