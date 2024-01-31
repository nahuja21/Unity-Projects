using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pea : MonoBehaviour
{ 
    void Update()
    {
        gameObject.transform.Translate(new Vector3(1 * GameValues.PeaSpeed, 0f, 0f));
        if(Game.Instance.IsRoundOver())
            Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
