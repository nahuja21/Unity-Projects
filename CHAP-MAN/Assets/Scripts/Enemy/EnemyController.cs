using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy enemy;
    private EnemyMovementController movementController;
    private EnemyStateMachine stateMachine;

    private GameObject pacman; // Reference to Pac-Man

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        movementController = GetComponent<EnemyMovementController>();
        stateMachine = enemy.stateMachine; // Assuming the state machine is attached to the same GameObject

        pacman = GameObject.FindWithTag("Pacman"); // Adjust tag as necessary
    }

    void Update()
    {
        HandleInitialMovement();
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 pacmanPosition = pacman.transform.position;
        Vector2 directionTowardsPacman = (pacmanPosition - (Vector2)transform.position).normalized;

        movementController.SetDirection(directionTowardsPacman, pacmanPosition);
        movementController.Move();
        
    }
    
    private bool isInitialMovement = true;

    private void HandleInitialMovement()
    {
        if (!isInitialMovement)
        {
            // Randomize the initial direction
            Vector2 randomDirection = GetRandomDirection();
            movementController.SetDirection(randomDirection, Vector2.zero);
            isInitialMovement = false;
        }
    }

    private Vector2 GetRandomDirection()
    {
        int random = UnityEngine.Random.Range(0, 4);
        switch (random)
        {
            case 0: return Vector2.up;
            case 1: return Vector2.down;
            case 2: return Vector2.left;
            case 3: return Vector2.right;
            default: return Vector2.zero;
        }
    }


    // Additional methods for decision-making, pathfinding, etc.
}