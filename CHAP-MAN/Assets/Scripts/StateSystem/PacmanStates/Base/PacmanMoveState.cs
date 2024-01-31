using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMoveState : PacmanState
{
    protected Vector2 dir;
    protected Vector2 lastDir;

    public PacmanMoveState(Pacman _pacman, PacmanStateMachine _stateMachine, string _name, int x, int y) : base(_pacman, _stateMachine, _name)
    {
        this.dir = new Vector2(x, y);
    }
    
    public override void Enter()
    {
        base.Enter();
    }
    
    public override void HandleInput()
    {
        base.HandleInput();

        if (moveAction.triggered)
        {
            Vector2 moveDir = moveAction.ReadValue<Vector2>();
            pacman.SetDirection(moveDir);
        }
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        pacman.Move();
    }
    
    public override void Exit()
    {
        base.Exit();
    }
}