using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitNode : Node
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPickedUp)
            return;
        if (!other.CompareTag("Pacman")) return;
        
        FindObjectOfType<LevelManager>().CollectFruit();
        
        base.MakeTransparent();
        isPickedUp = true;
    }
}
