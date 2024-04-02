using UnityEngine;
using UnityEngine.Pool;

// TODO поменять нейминг класса
public class BallPool : MonoBehaviour
{
    public enum PoolType
    {
        Stack,
        LinkedList
    }

    public PoolType poolType;
    public BallType ballType = BallType.BlueBall;
    public GameObject ballPref;

    // Collection checks will throw errors if we try to release an item that is already in the pool.
    public bool collectionChecks = true;
    public int maxPoolSize = 10;

    IObjectPool<Ball> m_Pool;

    public IObjectPool<Ball> Pool
    {
        get
        {
            if (m_Pool == null)
            {
                if (poolType == PoolType.Stack)
                    m_Pool = new ObjectPool<Ball>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
                else
                    m_Pool = new LinkedPool<Ball>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
            }
            return m_Pool;
        }
    }

    protected Ball CreatePooledItem()
    {
        var go = Instantiate(ballPref, transform, true);
        go.name = $"{ballType}_FromPool";

        Ball ball = go.AddComponent<Ball>();
        ball.Init(Pool, ballType);

        return ball;
    }

    // Called when an item is returned to the pool using Release
    void OnReturnedToPool(Ball ball)
    {
        ball.gameObject.SetActive(false);
    }

    // Called when an item is taken from the pool using Get
    void OnTakeFromPool(Ball ball)
    {
        ball.gameObject.SetActive(true);
    }

    // If the pool capacity is reached then any items returned will be destroyed.
    // We can control what the destroy behavior does, here we destroy the GameObject.
    void OnDestroyPoolObject(Ball ball)
    {
        Destroy(ball.gameObject);
    }
}
