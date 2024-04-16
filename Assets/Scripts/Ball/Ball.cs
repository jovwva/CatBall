using UnityEngine;
using UnityEngine.Pool;

public class Ball : MonoBehaviour {
    public BallType BallType { private set; get; }
    private IObjectPool<Ball> pool;
    private bool isActive = false;

    private SpriteRenderer spriteRenderer;

    public void Init(IObjectPool<Ball> pool, BallType ballType) {
        this.pool = pool;
        this.BallType = ballType;

        spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
    }

    public void ReleaseBall() {
        if (!isActive) return;

        isActive = false;
        pool.Release(this);
    } 

    public void SetPosition(Vector3 newPosition, Color newColor) {
        isActive = true;
        transform.position = newPosition;

        spriteRenderer.color = newColor;
    }
} 