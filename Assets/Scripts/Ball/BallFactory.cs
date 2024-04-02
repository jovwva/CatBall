using UnityEngine;

public enum BallType {
    AnyBall,
    BlueBall,
    RedBall,
}
// TODO поменять нейминг класса
public class BallFactory : MonoBehaviour
{
    [SerializeField] private BallPool       _ballPool;

    public int          ballSpawned = 0;
    public int          ballLimit   = 20;
    public float        spawnDelay  = .4f;
    public Transform    spawnPosition;
    
    private bool         _factoryState = true;
    private bool        _isleverOpen = false;
   
    public bool FactoryState {
        get { return _factoryState; }
        private set {
            if (!value && _factoryState)
            {
                EventBusHolder.Instance.EventBus.Raise(new PipeEmptiedEvent(gameObject));
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
        
        if (timer >= spawnDelay && _isleverOpen) {
            timer = 0f;
            
            Ball ball = _ballPool.Pool.Get();
            ball.SetPosition(spawnPosition.position);

            ballSpawned++;
        }
        if (ballSpawned >= ballLimit) {
            FactoryState = false;
        }
    }

    public void SwitchLever(){
        _isleverOpen = !_isleverOpen;
    }
}
