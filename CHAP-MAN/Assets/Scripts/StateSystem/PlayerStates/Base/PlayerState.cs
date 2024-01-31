using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState : BaseState
{

    /// <summary>
    /// The player is the entity that sits in the room. It has three states:
    ///     Playing Pacman
    ///     Turning around
    ///     Facing door
    /// </summary>
    
    public Player player;

    public PlayerStateMachine stateMachine;
    
    public InputAction turnAroundAction;
    public InputAction toggleLightAction;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _name)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.name = _name;

        turnAroundAction = player.playerInput.actions["TurnAround"];
        toggleLightAction = player.playerInput.actions["ToggleLight"];
    }

    public override void Enter()
    {
        // anim.SetBool(name, true);
    }
    
    public override void HandleInput()
    {
        throw new System.NotImplementedException();
    }
    
    public override void LogicUpdate()
    {
        throw new System.NotImplementedException();
    }
    
    public override void Exit()
    {
        // anim.SetBool(name, false);
    }
}
