using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateMachine
{
    public LevelState currentState;

    public void Initialize(LevelState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(LevelState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
