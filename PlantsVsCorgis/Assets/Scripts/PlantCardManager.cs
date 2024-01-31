using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCardManager : MonoBehaviour
{
    private PlantCard selectedPlantCard;

    public GameObject SunFlower;
    public GameObject PeaShooter;
    public GameObject BlueShooter;

    public static PlantCardManager Instance;
    
    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    public void PlantCardSelect(PlantCard card)
    {
        selectedPlantCard = card;
    }

    public GameObject GetSelectedPlantObject()
    {
        if (selectedPlantCard == PlantCard.PeaShooter)
            return PeaShooter;
        if (selectedPlantCard == PlantCard.SunFlower)
            return SunFlower;
        if (selectedPlantCard == PlantCard.BlueShooter)
            return BlueShooter;

        return null;
    }

    public PlantCard GetSelectedPlantType()
    {
        return selectedPlantCard;
    }

    public int GetPlantSunCost(PlantCard card)
    {
        if (card == PlantCard.PeaShooter)
            return 100;
        if (card == PlantCard.SunFlower)
            return 50;
        if (card == PlantCard.BlueShooter)
            return 175;
        return 0;
    }
}
