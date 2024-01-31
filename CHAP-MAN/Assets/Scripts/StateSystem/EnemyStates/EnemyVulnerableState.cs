

using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class EnemyVulnerableState : EnemyState
{

    public EnemyVulnerableState(Enemy _levelManager, EnemyStateMachine _stateMachine, string _name) : base(
        _levelManager, _stateMachine, _name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer += GameParameters.ghostVulnerableDuration;
        enemy.SetSprite(vulnerable: true);
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        stateTimer -= Time.deltaTime;

        if (stateTimer < 0)
        {
            enemy.stateMachine.ChangeState(enemy.normalState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Pacman")) return;

        enemy.EatenByPacman();
    }

    public override Vector2 AdjustMovementInput(Vector2 newDir)
    {
    if (Mathf.Abs(newDir.x) > Mathf.Abs(newDir.y))
    {
    return new Vector2(Mathf.Sign(newDir.x), 0);
    }

    return new Vector2(0, Mathf.Sign(newDir.y));
    }
}
