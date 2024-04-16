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

    public Color[] ballColorArray;
    private int colorArrayLength = 0;
    
    private bool         _factoryState = true;
    private bool        _isLeverOpen = false;
   
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

    private void Awake()
    {
        colorArrayLength = ballColorArray.Length;
    }
    private float timer = 0;

    private void Update()
    {
        if (!FactoryState) {
            return;
        }
        timer += Time.deltaTime; 
        
        if (timer >= spawnDelay && _isLeverOpen) {
            timer = 0f;
            
            Ball ball = _ballPool.Pool.Get();
            ball.SetPosition(spawnPosition.position, ballColorArray[Random.Range(0, colorArrayLength)]);

            ballSpawned++;
        }
        if (ballSpawned >= ballLimit) {
            FactoryState = false;
        }
    }

    // public bool SwitchLever(bool _isSwitchLever)
    // {
    //     _isSwitchLever = !_isSwitchLever;
    //     _isLeverOpen = _isSwitchLever;
    //     return(_isSwitchLever);
    // }

    public void ChangeState(bool isLeverOpen)
    {
        if (_isLeverOpen == isLeverOpen)
            return;
        _isLeverOpen = isLeverOpen;
    }
}
