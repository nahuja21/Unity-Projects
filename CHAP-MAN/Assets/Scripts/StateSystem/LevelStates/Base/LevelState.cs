using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LevelState : BaseState
{

    public LevelManager levelManager;

    public LevelStateMachine stateMachine;
    
    // references to all input actions related to the game

    public LevelState(LevelManager _levelManager, LevelStateMachine _stateMachine, string _name)
    {
        this.levelManager = _levelManager;
        this.stateMachine = _stateMachine;
        this.name = _name;
    }
    
    public override void Enter()
    {
    }
    
    public override void HandleInput()
    {
    }
    
    public override void LogicUpdate()
    {
    }
    
    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}
