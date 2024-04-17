using TMPro;
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
    [SerializeField] private TextMeshProUGUI ballCounter;

    public int          ballLimit   = 20;
    public float        spawnDelay  = .4f;
    public Transform    spawnPosition;

    public Color[]      ballColorArray;
    private int         colorArrayLength = 0;

    private float       timer = 0;
    private int         ballSpawned = 0;
    
    private bool        factoryState = true;
    private bool        isLeverOpen = false;
    private SoundBroker soundBroker;
   
    public bool IsFactoryActive {
        get { return factoryState; }
        private set {
            if (!value && factoryState)
            {
                EventBusHolder.Instance.EventBus.Raise(new PipeEmptiedEvent(gameObject));
            }
            factoryState = value;
        }   
    }

    private void Awake()
    {
        colorArrayLength = ballColorArray.Length;
        ballCounter.text = ballLimit.ToString();
    }
    private void Start()
    {
        soundBroker = SoundBroker.Instance;
    }

    private void Update()
    {
        if (!IsFactoryActive) {
            return;
        }
        timer += Time.deltaTime; 
        
        if (timer >= spawnDelay && isLeverOpen) {
            timer = 0f;
            
            Ball ball = _ballPool.Pool.Get();
            ball.SetPosition(spawnPosition.position, ballColorArray[Random.Range(0, colorArrayLength)]);
            soundBroker.PlaySound(SoundBroker.SoundType.BallSpawn);

            ballSpawned++;
            ballCounter.text = (ballLimit - ballSpawned).ToString();
        }
        if (ballSpawned >= ballLimit) {
            IsFactoryActive = false;
        }
    }

    public void ChangeState(bool isLeverOpen)
    {
        if (this.isLeverOpen == isLeverOpen)
            return;
        this.isLeverOpen = isLeverOpen;
    }
}
