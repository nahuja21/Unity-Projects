using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedState : GameState
{

    public GamePausedState(GameManager _gameManager, GameStateMachine _stateMachine, string _name) : base(_gameManager, _stateMachine, _name)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        
        gameManager.PauseGame();
    }
    public override void HandleInput()
    {
        base.HandleInput();

        if (togglePauseAction.triggered)
        {
            gameManager.stateMachine.ChangeState(gameManager.playingState);
        }
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
    public override void Exit()
    {
        base.Exit();
        
        gameManager.UnpauseGame();
    }
}
