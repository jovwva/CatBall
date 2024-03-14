public class RegistrationDestroy : BallRegistration
{
    protected override void RegisterBall(Ball ball)
    {
        EventBusHolder.Instance.EventBus.Raise(new BallDestroyedEvent(BallType.AnyBall));
        
        ball.ReleaseBall();
    }
}
