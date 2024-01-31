using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanIdleState : PacmanState
{
    private static readonly int Idle = Animator.StringToHash("Idle");
    public AudioSource audioSource;

    public PacmanIdleState(Pacman _pacman, PacmanStateMachine _stateMachine, string _name) : base(_pacman, _stateMachine, _name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entering IDLE State");
        pacman.anim.SetTrigger("isIdle");
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (moveAction.triggered)
        {
            pacman.stateMachine.ChangeState(pacman.moveRightState);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


    }

    public override void Exit()
    {
        base.Exit();
        pacman.anim.ResetTrigger("isIdle");
    }
}
