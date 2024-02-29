using UnityEngine;

public enum BallType {
    BlueBall,
    RedBall,
}

public class BallFactory : MonoBehaviour
{
    [SerializeField] private EventBusHolder _busHolder;
    [SerializeField] private BallPool       _ballPool;

    public int          ballSpawned = 0;
    public int          ballLimit   = 20;
    public float        spawnDelay  = .4f;

    private bool         _factoryState = true;
    public bool FactoryState {
        get { return _factoryState; }
        private set {
            if (!value && _factoryState)
            {
                _busHolder.EventBus.Raise(new PipeEmptiedEvent(gameObject));
            }
            _factoryState = value;
        }   
    }

    private float timer = 0;

    private void Update()
    {
        if (!FactoryState) {
            return;
        }
        timer += Time.deltaTime; 

        if (timer >= spawnDelay) {
            timer = 0f;
            
            Ball ball = _ballPool.Pool.Get();
            ball.SetPosition(transform.position);

            ballSpawned++;
        }
        if (ballSpawned >= ballLimit) {
            FactoryState = false;
        }
    }
}
