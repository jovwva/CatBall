using System;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour, IEventReceiver<BallDestroyedEvent>, IEventReceiver<PipeEmptiedEvent>, IEventReceiver<BallApprovedEvent>
{
    [SerializeField] private EventBusHolder _eventBusHolder;
    [Header("Level data")]
    public int ballsCount;
    public int ballsWinCount;
    public int ballsDestroyed = 0;
    public float ballApproved = 0;

    [Header("UI Link")]
    public StarIndicator starIndicator;

    private void Start()
    {
        _eventBusHolder.EventBus.Register(this as IEventReceiver<BallDestroyedEvent>);
        _eventBusHolder.EventBus.Register(this as IEventReceiver<BallApprovedEvent>);
        _eventBusHolder.EventBus.Register(this as IEventReceiver<PipeEmptiedEvent>);
    }

    private void OnDisable()
    {
        _eventBusHolder.EventBus.Unregister(this as IEventReceiver<BallDestroyedEvent>);
        _eventBusHolder.EventBus.Unregister(this as IEventReceiver<BallApprovedEvent>);
        _eventBusHolder.EventBus.Register(this as IEventReceiver<PipeEmptiedEvent>);
    }

    #region IEventReceiver
    public UniqueId Id { get; } = new UniqueId();
    public void OnEvent(BallDestroyedEvent @event) {
        BallDestroyed();
    } 
    public void OnEvent(PipeEmptiedEvent @event)  => Debug.Log($"В трубе {@event.PipeObject.name} закончились шарики!");

    public void OnEvent(BallApprovedEvent @event) {
        BallApproved();
    } 
    #endregion

    private void BallDestroyed() {
        ballsDestroyed++;

        if (ballsDestroyed >= ballsCount) {
            LevelPass();
        }
    }

    private void BallApproved() {
        ballsDestroyed++;
        ballApproved++;

        starIndicator.UpdateStarIndicator(ballApproved / ballsWinCount);
    }

    public void LevelPass() {
        Debug.Log("Все шарики были уничтожены");
    }
}
