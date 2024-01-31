

using UnityEngine;

public class EnemyNormalState : EnemyState
{

    public EnemyNormalState(Enemy _levelManager, EnemyStateMachine _stateMachine, string _name) : base(_levelManager, _stateMachine, _name)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        enemy.SetSprite(vulnerable: false);
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
    }
    
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Pacman")) return;
        
        other.GetComponent<Pacman>().PacmanIsEaten();
    }

    public override Vector2 AdjustMovementInput(Vector2 newDir)
    {
        if (Mathf.Abs(newDir.x) > Mathf.Abs(newDir.y))
        {
            return new Vector2(-Mathf.Sign(newDir.x), 0);
        }
        
        return new Vector2(0, -Mathf.Sign(newDir.y));
    }
}
