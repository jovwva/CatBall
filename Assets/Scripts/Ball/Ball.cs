using UnityEngine;
using UnityEngine.Pool;

public class Ball : MonoBehaviour {
    public BallType BallType { private set; get; }
    private IObjectPool<Ball> pool;
    private bool isActive = false;

    public void Init(IObjectPool<Ball> pool, BallType ballType) {
        this.pool = pool;
        this.BallType = ballType;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ball")){
            EventBusHolder.Instance.EventBus.Raise(new BallDestroyedEvent(BallType.AnyBall));
            ReleaseBall();
        }
    }

    public void ReleaseBall() {
        if (!isActive) return;

        isActive = false;
        pool.Release(this);
    } 

    public void SetPosition(Vector3 newPosition) {
        isActive = true;
        transform.position = newPosition;
    }
} 