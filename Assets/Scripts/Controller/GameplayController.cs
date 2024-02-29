using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [Header("Level data")]
    public int ballsCount;
    public int ballsDestroyed;

    public void BallDestroyed()
    {
        ballsDestroyed++;

        if (ballsDestroyed >= ballsCount)
        {
            LevelPass();
        }
    }

    public void LevelPass()
    {
        Debug.Log("Шарики закончились");
    }
}
