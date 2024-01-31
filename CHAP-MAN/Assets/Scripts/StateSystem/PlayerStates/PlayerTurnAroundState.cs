
 
public class PlayerTurnAroundState : PlayerState
{
    // Player is neither facing the door nor "playing" pacman
    // Player cannot control pacman in this state
    // This state exists for transition/animation purposes
    
    public PlayerTurnAroundState(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
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
}

