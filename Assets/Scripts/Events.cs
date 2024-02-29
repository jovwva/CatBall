using UnityEngine;

public readonly struct BallDestroyedEvent : IEvent
{
    public readonly BallType BallType;

    public BallDestroyedEvent(BallType ballType)
    {
        BallType = ballType;
    }
}

public readonly struct PipeEmptiedEvent : IEvent
{
    public readonly GameObject PipeObject;

    public PipeEmptiedEvent(GameObject pipeObject)
    {
        PipeObject = pipeObject;
    }
}