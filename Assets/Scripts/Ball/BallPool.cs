using UnityEngine;
using UnityEngine.Pool;

public class BallPool : MonoBehaviour
{
    public enum PoolType
    {
        Stack,
        LinkedList
    }

    public PoolType poolType;
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

    Ball CreatePooledItem()
    {
        var go = Instantiate(ballPref, transform, true);
        go.name = "BallFromPool";

        var ball = go.AddComponent<Ball>();
        ball.pool = Pool;

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
