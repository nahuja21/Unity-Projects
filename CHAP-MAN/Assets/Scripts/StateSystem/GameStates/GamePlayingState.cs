using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayingState : GameState
{

    public GamePlayingState(GameManager _gameManager, GameStateMachine _stateMachine, string _name) : base(_gameManager, _stateMachine, _name)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
    }
    public override void HandleInput()
    {
        base.HandleInput();

        if (togglePauseAction.triggered)
        {
            gameManager.stateMachine.ChangeState(gameManager.pausedState);
        }
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
    public override void Exit()
    {
        base.Exit();
    }
}
