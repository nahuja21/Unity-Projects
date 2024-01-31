using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public string name;
    
    // helper fields
    public float stateTimer;
    public bool stateTrigger;
    
    // core functionality
    public abstract void Enter();
    public abstract void HandleInput();
    public abstract void LogicUpdate();
    public abstract void Exit();
}