using UnityEngine;

public class PipeDestroyer : MonoBehaviour
{
    [Header("Link")]
    [SerializeField] private LevelManager levelManager;
    [Space]

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
        levelManager.BallPass();
        ball.ReaturnToPool();
    }
}