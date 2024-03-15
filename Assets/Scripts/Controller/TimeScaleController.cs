using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleController : MonoBehaviour
{
    [SerializeField] private GameState gameState = GameState.Normal;

    public void ChangeGameState(GameState newState) {
        if (newState == gameState) return;

        Time.timeScale = GetTimeScale(newState);
        Time.fixedDeltaTime = Time.timeScale * .02f;
        gameState = newState;
    }

    private float GetTimeScale(GameState state) => 
        state switch
        {
            GameState.Normal => 1f,
            GameState.Slow   => 0.2f,
            GameState.Pause  => 0f,
            _ => throw new ArgumentException("ISC!!!")
        };
}
