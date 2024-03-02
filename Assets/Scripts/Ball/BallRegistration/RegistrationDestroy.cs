public class RegistrationDestroy : BallRegistration
{
    protected override void RegisterBall(Ball ball)
    {
        _busHolder.EventBus.Raise(new BallDestroyedEvent(BallType.AnyBall));
        
        ball.ReleaseBall();
    }
}
