using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMoveUpState : PacmanMoveState
{
    public PacmanMoveUpState(Pacman _pacman, PacmanStateMachine _stateMachine, string _name, int x = 1, int y = 0) : base(_pacman, _stateMachine, _name, x, y)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entering MOVEUP State");
        pacman.anim.SetTrigger("isMovingUp");
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
        pacman.anim.ResetTrigger("isMovingUp");
    }
}
