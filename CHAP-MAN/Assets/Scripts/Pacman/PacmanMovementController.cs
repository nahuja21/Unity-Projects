using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovementController : MonoBehaviour
{
    // Credit: https://www.youtube.com/watch?v=60spz2evJcA&t=1s
    
    [SerializeField] private float nodeComparisonTolerance = 0.05f;
    [SerializeField] private GameObject currentNode;
    [SerializeField] private float moveSpeed = 3f;

    protected Vector2 direction;
    private Vector2 lastDirection;
    private bool reverseMovement;

    private Pacman pacman;

    private void Awake()
    {
        pacman = GetComponent<Pacman>();
    }

    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, moveSpeed * Time.deltaTime);
        
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
                //enemy.ChangeMoveState(direction)
                pacman.ChangeMoveState(direction);
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

    public void SetDirection(Vector2 newDir)
    {
        if (direction == -newDir)
        {
            reverseMovement = true;
        }
        direction = newDir;
    }
}
