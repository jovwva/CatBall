using UnityEngine;
using UnityEngine.Pool;

public class Ball : MonoBehaviour
{
    public BallType BallType { private set; get; }
    private IObjectPool<Ball> pool;

    public void Init(IObjectPool<Ball> pool, BallType ballType) {
        this.pool = pool;
        this.BallType = ballType;
    }

    public void ReleaseBall() => pool.Release(this);

    public void SetPosition(Vector3 newPosition) => transform.position = newPosition;
}
