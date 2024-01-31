using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupNode : Node
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPickedUp)
            return;
        if (!other.CompareTag("Pacman")) return;
        
        base.MakeTransparent();
        
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.CollectFruit();
        levelManager.MakeGhostsVulnerable();
        isPickedUp = true;
    }
}
