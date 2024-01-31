using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMoveLeftState : PacmanMoveState
{
    public PacmanMoveLeftState(Pacman _pacman, PacmanStateMachine _stateMachine, string _name, int x = 1, int y = 0) : base(_pacman, _stateMachine, _name, x, y)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        pacman.anim.SetTrigger("isMovingLeft");
    }
    
    public override void HandleInput()
    {
        base.HandleInput();

    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
    }
    
    public override void Exit()
    {
        base.Exit();
        pacman.anim.ResetTrigger("isMovingLeft");
    }
}
