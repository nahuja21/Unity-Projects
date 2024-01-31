using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class SunFlower : MonoBehaviour
{
    public GameObject SunSunflower;

    private GameObject currentSun = null;

    void Start()
    {
        StartCoroutine(Blossom());

        //One position have them spawn on sunflower. Have them spawn faster then normal 
        //Use the code from game.cs IEnumerator SpawnSun and make it spawn a little more.
    }
    
    
    
    IEnumerator Blossom()
    {
        while (!Game.Instance.IsRoundOver())
        {
            yield return new WaitForSeconds(6);
            if (currentSun == null)
            {
                currentSun = Instantiate(SunSunflower,
                    new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                    Quaternion.identity);
                yield return new WaitForSeconds(6);
            }
        }

    }

    private void Update()
    {
        if(Game.Instance.IsRoundOver())
            Destroy(gameObject);
    }
    
}
