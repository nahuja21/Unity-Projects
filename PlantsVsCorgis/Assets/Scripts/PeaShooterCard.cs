using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterCard : MonoBehaviour
{
    public GameObject PeaShooter;
    
    public void OnPress()
    {
        PlantCardManager.Instance.PlantCardSelect(PlantCard.PeaShooter);
    }
}
