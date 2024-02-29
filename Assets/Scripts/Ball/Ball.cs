using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Ball : MonoBehaviour
{
    public IObjectPool<Ball> pool;

    public void Test() => pool.Release(this);

    public void SetPosition(Vector3 newPosition) => transform.position = newPosition;
}
