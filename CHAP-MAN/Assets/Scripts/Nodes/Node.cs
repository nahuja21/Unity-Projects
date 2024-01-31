using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float neighborSearchDistance = 1.1f;
    public bool canMoveLeft, canMoveRight, canMoveUp, canMoveDown;
    protected bool isPickedUp = false;

    public GameObject nodeLeft, nodeRight, nodeUp, nodeDown;
    
    // Start is called before the first frame update
    void Awake()
    {
        SetDirectionNodes();
    }

    private void Start()
    {
        FindObjectOfType<LevelManager>().nodesRemaining += 1;
    }

    protected void MakeTransparent()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.clear;
    }

    public GameObject GetNodeFromDirection(Vector2 direction)
    {
        if (direction == Vector2.right && canMoveRight) return nodeRight;
        if (direction == Vector2.left && canMoveLeft) return nodeLeft;
        if (direction == Vector2.up && canMoveUp) return nodeUp;
        if (direction == Vector2.down && canMoveDown) return nodeDown;

        return null;
    }

    void SetDirectionNodes()
    {
        FindNodeInDirection(1, 0, ref nodeRight, ref canMoveRight);  // right
        FindNodeInDirection(-1, 0, ref nodeLeft, ref canMoveLeft);  // left
        FindNodeInDirection(0, 1, ref nodeUp, ref canMoveUp);  // up
        FindNodeInDirection(0, -1, ref nodeDown, ref canMoveDown);  // down
        
    }

    void FindNodeInDirection(int x, int y, ref GameObject toSet, ref bool toSetBool)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, new Vector2(x, y));

        foreach (RaycastHit2D hit in hits)
        {
            if (!hit.collider.CompareTag("Node")) continue;
            if (!(hit.distance < neighborSearchDistance)) continue;
            
            toSetBool = true;
            toSet = hit.collider.gameObject;
        }
    }

    public List<Vector2> GetAvailableDirections()
    {
        List<Vector2> dirs = new List<Vector2>();
        
        if (nodeRight != null) dirs.Add(nodeRight.transform.position);
        if (nodeLeft != null) dirs.Add(nodeLeft.transform.position);
        if (nodeUp != null) dirs.Add(nodeUp.transform.position);
        if (nodeDown != null) dirs.Add(nodeDown.transform.position);
        foreach (var obj in dirs) Debug.Log(obj);
        return dirs;

    }
}
