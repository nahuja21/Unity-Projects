using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCard : MonoBehaviour
{
    public GameObject BlueShooter;
    
    public void OnPress()
    {
        PlantCardManager.Instance.PlantCardSelect(PlantCard.BlueShooter);
    }
}
