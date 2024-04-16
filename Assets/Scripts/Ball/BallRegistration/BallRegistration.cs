using UnityEngine;

public abstract class BallRegistration  : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D other)
    {
        // Если это шарик, то отправляем его на регистрацию
        if (other.transform.parent.TryGetComponent<Ball>( out Ball ball))
        {
            RegisterBall(ball);
        }
    }

    protected abstract void RegisterBall(Ball ball);
}
