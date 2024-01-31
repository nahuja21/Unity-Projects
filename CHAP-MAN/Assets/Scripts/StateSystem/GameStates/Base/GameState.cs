using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameState : BaseState
{

    public GameManager gameManager;

    public GameStateMachine stateMachine;
    
    // references to all input actions related to the game
    public InputAction togglePauseAction;

    public GameState(GameManager _gameManager, GameStateMachine _stateMachine, string _name)
    {
        this.gameManager = _gameManager;
        this.stateMachine = _stateMachine;
        this.name = _name;

        togglePauseAction = gameManager.playerInput.actions["Pause"];
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
    }
}
