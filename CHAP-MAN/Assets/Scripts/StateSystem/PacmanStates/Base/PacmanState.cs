using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PacmanState : BaseState
{

    /// <summary>
    /// The pacman is the entity that is actually playing the game. It has four states:
    ///     Move (pacman is moving; pacman's mouth is opening and closing)
    ///     Stuck (pacman is stuck against a wall; pacman's mouth stays open)
    ///     OutOfGame (before or after game starts or ends; pacman's mouth stays closed)
    /// </summary>
    
    public Pacman pacman;

    public PacmanStateMachine stateMachine;
    
    // references to all input actions related to pacman
    public InputAction moveAction;
    public InputAction toggleFlashlightAction;

    public PacmanState(Pacman _pacman, PacmanStateMachine _stateMachine, string _name)
    {
        this.pacman = _pacman;
        this.stateMachine = _stateMachine;
        this.name = _name;
        
        moveAction = pacman.playerInput.actions["Move"];
    }

    public override void Enter()
    {
        //pacman.anim.SetTrigger("isIdle");
    }
    
    public override void HandleInput()
    {
        // throw new System.NotImplementedException();
    }
    
    public override void LogicUpdate()
    {
        // throw new System.NotImplementedException();
    }
    
    public override void Exit()
    {
        // pacman.anim.ResetTrigger("isIdle");
    }
}
