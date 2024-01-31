using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlowerCard : MonoBehaviour
{
    public GameObject SunFlower;
    
    public void OnPress()
    {
        PlantCardManager.Instance.PlantCardSelect(PlantCard.SunFlower);
    }
}
