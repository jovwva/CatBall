using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level requirements")]
    [SerializeField] private int reqBallCount_OneStar;
    [SerializeField] private int reqBallCount_TwoStar;
    [SerializeField] private int reqBallCount_ThreeStar;
    [Space]
    [SerializeField] private int ballCount;

    public void BallPass()
    {
        ballCount++;
    }
    public void OutOfBall()
    {
        Debug.Log($"Уровень завершен! Ваш результат: {GetResult()}");
    }

    private string GetResult()
    {
        // Можно перейти на for с убыванием, для этого можно требования хранить List для перебора;
        if (ballCount >= reqBallCount_ThreeStar)
        {
            return "3 звезды";
        }
        else if (ballCount >= reqBallCount_TwoStar)
        {
            return "2 звезды";
        }
        else if (ballCount >= reqBallCount_OneStar)
        {
            return "1 звезда";
        }
        else
        {
            return "Разочарование!";
        }
    }    
}
