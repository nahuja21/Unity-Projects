using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNode : Node
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPickedUp)
            return;
        if (!other.CompareTag("Pacman")) return;
        
        FindObjectOfType<LevelManager>().CollectNode();
        
        base.MakeTransparent();
        isPickedUp = true;
    }
    
    
}
