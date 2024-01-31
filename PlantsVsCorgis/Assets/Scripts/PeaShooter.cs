using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : PlantShooter
{
    public GameObject PeaObject;
    void Awake()
    {
        Pea = PeaObject;
        SecondsBetweenPeas = GameValues.PeaShooterSpawnTime;
    }
    
}
