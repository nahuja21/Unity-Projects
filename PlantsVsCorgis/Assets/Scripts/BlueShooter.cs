using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueShooter : PlantShooter
{
    public GameObject PeaObject;
    void Awake()
    {
        Pea = PeaObject;
        SecondsBetweenPeas = GameValues.BlueShooterSpawnTime;
    }
}
