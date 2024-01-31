using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanStateMachine
{
    public PacmanState currentState;
    public AudioSource audioSource;

    public void Initialize(PacmanState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(PacmanState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
