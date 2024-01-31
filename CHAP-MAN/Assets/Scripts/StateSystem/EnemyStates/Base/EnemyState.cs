using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class EnemyState : BaseState
{

    public Enemy enemy;

    public EnemyStateMachine stateMachine;
    
    // references to all input actions related to the game

    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string _name)
    {
        this.enemy = _enemy;
        this.stateMachine = _stateMachine;
        this.name = _name;
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

    public virtual void OnTriggerEnter2D(Collider2D other) { }

    public virtual Vector2 AdjustMovementInput(Vector2 newDir)
    {
        return Vector2.zero;
    }
}
