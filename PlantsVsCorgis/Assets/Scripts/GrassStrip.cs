using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GrassStrip : MonoBehaviour
{
    // List of all the plants on the grass strip
    private List<GameObject> plants = new List<GameObject>();
    private List<GameObject> corgis = new List<GameObject>();
    private int numberOfCorgisSpawned = 0;

    public GameObject basicCorgi;
    public GameObject intermediateCorgi;
    public GameObject advancedCorgi;

    private void Start()
    {
        StartCoroutine(StartOfGameDelay());
    }

    public void Reset()
    {
        numberOfCorgisSpawned = 0;
        plants = new List<GameObject>();
        corgis = new List<GameObject>();
    }

    private void OnMouseDown()
    {
        SpawnPlant();
    }

    private void SpawnPlant()
    {
        GameObject selectedPlant = PlantCardManager.Instance.GetSelectedPlantObject();
        if (selectedPlant != null && plants.Count < GameValues.PlantGrassXPositions.Count)
        {
            GameObject newPlant = Instantiate(selectedPlant, new Vector3(GameValues.PlantGrassXPositions[plants.Count], gameObject.transform.position.y, 0f),
                Quaternion.identity);
            newPlant.transform.parent = gameObject.transform;
            plants.Add(newPlant);
            Sounds.Instance.PlayPlantSpawn();
            Game.Instance.DecreaseSunCount(PlantCardManager.Instance.GetPlantSunCost(PlantCardManager.Instance.GetSelectedPlantType()));
            PlantCardManager.Instance.PlantCardSelect(PlantCard.None);
        }
    }

    private GameObject DetermineTypeOfCorgi()
    {
        int randomNum = Random.Range(0, 100);
        if (randomNum <= GameValues.AdvancedCorgiSpawnChanceByLevel[Game.Instance.GetCurrentLevel()])
        {
            return advancedCorgi;
        }
        else if (randomNum <= GameValues.IntermediateCorgiSpawnChanceByLevel[Game.Instance.GetCurrentLevel()])
        {
            return intermediateCorgi;
        }
        else
        {
            return basicCorgi;
        }
    }
    
    IEnumerator StartOfGameDelay()
    {
        yield return new WaitForSeconds(GameValues.StartOfGameDelayByLevel[Game.Instance.GetCurrentLevel()]);
        StartCoroutine(SpawnCorgi());
    }
    IEnumerator SpawnCorgi()
    {
        yield return new WaitForSeconds(Random.Range(GameValues.CorgiSpawnTimeMinByLevel[Game.Instance.GetCurrentLevel()], GameValues.CorgiSpawnTimeMaxByLevel[Game.Instance.GetCurrentLevel()]));
        GameObject newCorgi = Instantiate(DetermineTypeOfCorgi(), new Vector3(12f,gameObject.transform.position.y,0f), Quaternion.identity);
        newCorgi.transform.parent = gameObject.transform;
        corgis.Add(newCorgi);
        numberOfCorgisSpawned++;
        if (numberOfCorgisSpawned < GameValues.NumberCorgisPerLevel[Game.Instance.GetCurrentLevel()])
        {
            StartCoroutine(SpawnCorgi());
        }
    }

    public bool AreAllCorgisDefeated()
    {
        if (numberOfCorgisSpawned >= GameValues.NumberCorgisPerLevel[Game.Instance.GetCurrentLevel()] && corgis.Count <= 0)
            return true;
        return false;
    }

    public void DeleteCorgi(GameObject corgi)
    {
        corgis.Remove(corgi);
    }

    public void DeletePlant(GameObject plant)
    {
        plants.Remove(plant);
    }

    public bool AreThereCorgis()
    {
        if (corgis.Count > 0)
            return true;
        return false;
    }
}
