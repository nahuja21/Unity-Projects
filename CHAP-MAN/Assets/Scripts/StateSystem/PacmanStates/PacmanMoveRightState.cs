﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMoveRightState : PacmanMoveState
{
    public PacmanMoveRightState(Pacman _pacman, PacmanStateMachine _stateMachine, string _name, int x = 1, int y = 0) : base(_pacman, _stateMachine, _name, x, y)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        pacman.anim.SetTrigger("isMovingRight");
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
        pacman.anim.ResetTrigger("isMovingRight");
    }
}
