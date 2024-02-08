using UnityEngine;

public class PipeDestroyer : MonoBehaviour
{
    [SerializeField] private int destroyedBallCount = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            DestroyBall(ball);
        }
    }
    private void DestroyBall(Ball ball)
    {
        destroyedBallCount++;
        ball.ReaturnToPool();
    }
}