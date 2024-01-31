

public class PlayerPlayPacmanState : PlayerState
{
    // Player is not facing the door, and is "playing" pacman
    // Player can control Pacman in this state
    
    public PlayerPlayPacmanState(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
    }
    
    public override void HandleInput()
    {
        base.HandleInput();

        if (turnAroundAction.triggered) stateMachine.ChangeState(player.turnAroundState);
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
