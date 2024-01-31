using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantShooter : MonoBehaviour
{
    protected GameObject Pea;
    protected int SecondsBetweenPeas;

    void Start()
    {
        StartCoroutine(SpawnPeas());
    }

    private void Update()
    {
        if(Game.Instance.IsRoundOver())
            Destroy(gameObject);
    }

    IEnumerator SpawnPeas()
    {
        yield return new WaitForSeconds(SecondsBetweenPeas);
        if(AreThereEnemies())
            ShootPea();
        // If enemy exists in row, spawn more peas
        StartCoroutine(SpawnPeas());
    }

    private void ShootPea()
    {
        Vector3 spawnLocation = gameObject.transform.position + new Vector3(0.7f, 0.35f, 0);
        Instantiate(Pea, spawnLocation, Quaternion.identity);
    }

    private bool AreThereEnemies()
    {
        return gameObject.GetComponentInParent<GrassStrip>().AreThereCorgis();
    }
}
