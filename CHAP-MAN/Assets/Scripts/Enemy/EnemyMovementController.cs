using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyMovementController : MonoBehaviour
{
    
    [SerializeField] private float nodeComparisonTolerance = 0.05f;
    [SerializeField] public GameObject currentNode;

    public Vector2 direction;
    private Vector2 lastDirection;
    private bool reverseMovement;

    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, GameParameters.ghostMoveSpeed * Time.deltaTime);
        
        DoMoveCheck();
    }

    protected void DoMoveCheck()
    {
        // if in in the middle of a node or wants to reverse directions
        if ((Mathf.Abs(transform.position.x - currentNode.transform.position.x) < nodeComparisonTolerance &&
             Mathf.Abs(transform.position.y - currentNode.transform.position.y) < nodeComparisonTolerance) || reverseMovement)
        {
            reverseMovement = false;
            
            GameObject nextNode = currentNode.GetComponent<Node>().GetNodeFromDirection(direction);
            // there is a path from current node to the wanted direction
            if (nextNode is not null)
            {
                //set this up when jesse does art
                //enemy.ChangeMoveState(direction);
                currentNode = nextNode;
                lastDirection = direction;
            }
            // there is no path from the current node to the wanted direction
            else
            {
                direction = lastDirection;
                // check to see if there
                nextNode = currentNode.GetComponent<Node>().GetNodeFromDirection(direction);
                if (nextNode is not null)
                {
                    currentNode = nextNode;
                }
            }
        }
    }

    public void SetDirection(Vector2 newDir, Vector2 pacmanPosition)
    {
        Vector2 adjustedDirection = enemy.stateMachine.currentState.AdjustMovementInput(newDir);

        if (direction == -adjustedDirection) return;

        List<Vector2> nextNodeCoordinates = currentNode.GetComponent<Node>().GetAvailableDirections();

        Vector2 bestDir = adjustedDirection;
        float bestDistance = float.PositiveInfinity;
        
        foreach (Vector2 coord in nextNodeCoordinates)
        {
            if (DistanceToPacman(pacmanPosition, coord) < bestDistance)
            {
                bestDir = enemy.stateMachine.currentState.AdjustMovementInput(((Vector2)transform.position - coord).normalized);
                bestDistance = DistanceToPacman(pacmanPosition, coord);
            }
        }
        
        direction = bestDir;
    }

    float DistanceToPacman(Vector2 pacmanPos, Vector2 otherPos) => Vector2.Distance(pacmanPos, otherPos);
    
    private Vector2 FixMovementInput(Vector2 dir)
    {
        if (dir.x == 0) return new Vector2(dir.y + Mathf.Sign(dir.y), dir.y);
        if (dir.y == 0) return new Vector2(dir.x, dir.x + Mathf.Sign(dir.x));

        return dir;
    }
    
    private bool CheckForWall(Vector2 dir) => Physics2D.Raycast(transform.position, dir, 1, LayerMask.NameToLayer("Wall"));
    
    
//PLS WORK
    public GameObject CurrentNode
    {
        get { return currentNode; }
    }
    protected Vector2 direction1;

    // Public property to get the direction value
    public Vector2 Direction
    {
        get { return direction1; }
    }

    public bool LeadsToCorner(Vector2 currentDirection)
    {
        Node currentNodeScript = currentNode.GetComponent<Node>();

        // Get available directions except for the reverse of the current direction (ghosts shouldn't reverse direction)
        Vector2[] possibleDirections = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        Vector2 reverseDirection = -currentDirection; // The direction the ghost came from
        List<Vector2> availableDirections = new List<Vector2>();

        foreach (var dir in possibleDirections)
        {
            if (dir != reverseDirection && currentNodeScript.GetNodeFromDirection(dir) != null)
            {
                availableDirections.Add(dir);
            }
        }

        // It's a corner if there's less than two available directions to move into
        return availableDirections.Count < 2;
    }

}




