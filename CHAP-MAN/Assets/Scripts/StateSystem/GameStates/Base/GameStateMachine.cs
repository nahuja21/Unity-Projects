using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    public GameState currentState;

    public void Initialize(GameState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(GameState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
