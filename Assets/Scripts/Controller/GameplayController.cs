using System;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour, IEventReceiver<BallDestroyedEvent>, IEventReceiver<PipeEmptiedEvent>
{
    [SerializeField] private EventBusHolder _eventBusHolder;
    [Header("Level data")]
    public int ballsCount;
    public int ballsDestroyed;

    private void OnEnable()
    {
        _eventBusHolder.EventBus.Register(this as IEventReceiver<BallDestroyedEvent>);
        _eventBusHolder.EventBus.Register(this as IEventReceiver<PipeEmptiedEvent>);
    }

    private void OnDisable()
    {
        _eventBusHolder.EventBus.Unregister(this as IEventReceiver<BallDestroyedEvent>);
        _eventBusHolder.EventBus.Unregister(this as IEventReceiver<PipeEmptiedEvent>);
    }

    #region IEventReceiver
    public UniqueId Id { get; } = new UniqueId();
    public void OnEvent(BallDestroyedEvent @event) {
        Debug.Log( @event.BallType );
        BallDestroyed();
    } 
    public void OnEvent(PipeEmptiedEvent @event)    => Debug.Log($"В трубе {@event.PipeObject.name} закончились шарики!");
    #endregion

    private void BallDestroyed()
    {
        ballsDestroyed++;

        if (ballsDestroyed >= ballsCount)
        {
            LevelPass();
        }
    }

    public void LevelPass()
    {
        Debug.Log("Все шарики были уничтожены");
    }
}
