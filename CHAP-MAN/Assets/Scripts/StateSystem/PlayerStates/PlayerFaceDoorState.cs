public class PlayerFaceDoorState : PlayerState
{
    // Player is facing the door
    // Player should not be allowed to control pacman while in this state
    
    public PlayerFaceDoorState(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
    }
    
    public override void HandleInput()
    {
        base.HandleInput();
        
        if (turnAroundAction.triggered) stateMachine.ChangeState(player.playPacmanState);
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
