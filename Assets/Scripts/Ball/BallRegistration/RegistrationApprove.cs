using UnityEngine;

public class RegistrationApprove : BallRegistration
{
    [SerializeField] private BallType requiredBallType = BallType.AnyBall;
    protected override void RegisterBall(Ball ball)
    {
        if (requiredBallType == ball.BallType) {
            EventBusHolder.Instance.EventBus.Raise(new BallApprovedEvent(ball.BallType));
        } else {
            EventBusHolder.Instance.EventBus.Raise(new BallDestroyedEvent(BallType.AnyBall));
        }
        
        ball.ReleaseBall();
    }
}
