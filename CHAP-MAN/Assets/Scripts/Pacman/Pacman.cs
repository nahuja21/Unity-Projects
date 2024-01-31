using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Pacman : MonoBehaviour
{
    [Header("Components")]
    [HideInInspector] public Animator anim;
    private Rigidbody2D rb;

    [Header("Movement")]
    public PacmanMovementController movementController;
    public AudioSource audioSource;
    private bool isMoving = false;

    public PlayerInput playerInput;

    public PacmanStateMachine stateMachine;
    
    public PacmanMoveRightState moveRightState;
    public PacmanMoveLeftState moveLeftState;
    public PacmanMoveUpState moveUpState;
    public PacmanMoveDownState moveDownState;

    void Awake()
    {
        this.anim = GetComponentInChildren<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        this.stateMachine = new PacmanStateMachine();
        
        this.moveRightState = new PacmanMoveRightState(this, stateMachine, "Move", 1, 0);
        this.moveLeftState = new PacmanMoveLeftState(this, stateMachine, "Move", -1, 0);
        this.moveUpState = new PacmanMoveUpState(this, stateMachine, "Move", 0, 1);
        this.moveDownState = new PacmanMoveDownState(this, stateMachine, "Move", 0, -1);

        this.stateMachine.Initialize(this.moveRightState);

        Time.timeScale = 1f;
    }

    private void Update()
    {
        stateMachine.currentState.HandleInput();
        stateMachine.currentState.LogicUpdate();
    }

    #region Movement
    public void Move()
    {
        movementController.Move();
    }

    public void SetDirection(Vector2 newDir)
    {
        movementController.SetDirection(newDir);
    }

    public void ChangeMoveState(Vector2 moveDir)
    {
        if (moveDir == Vector2.right) stateMachine.ChangeState(moveRightState);
        if (moveDir == Vector2.left) stateMachine.ChangeState(moveLeftState);
        if (moveDir == Vector2.up) stateMachine.ChangeState(moveUpState);
        if (moveDir == Vector2.down) stateMachine.ChangeState(moveDownState);

        if (isMoving == false){
          audioSource.loop = true;
          audioSource.Play();
          isMoving = true;
        }
    }

    public void StopMoving(){
        isMoving = false;
        audioSource.loop = false;
        audioSource.Stop();
    }

    #endregion

    public void PacmanIsEaten()
    {
        // stateMachine.ChangeState(deadState);
        FindObjectOfType<LevelManager>().EndLevel(false);
    }

    private void OnDrawGizmos()
    {

    }
}
