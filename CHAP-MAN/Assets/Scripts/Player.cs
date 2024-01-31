using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerInput playerInput;

    public PlayerStateMachine stateMachine;

    public PlayerPlayPacmanState playPacmanState;
    public PlayerTurnAroundState turnAroundState;
    public PlayerFaceDoorState faceDoorState;
    
    public Player()
    {
        this.stateMachine = new PlayerStateMachine();
        
        this.playPacmanState = new PlayerPlayPacmanState(this, stateMachine, "PlayPacman");
        this.turnAroundState = new PlayerTurnAroundState(this, stateMachine, "TurnAround");
        this.faceDoorState = new PlayerFaceDoorState(this, stateMachine, "FaceDoor");

    }
}