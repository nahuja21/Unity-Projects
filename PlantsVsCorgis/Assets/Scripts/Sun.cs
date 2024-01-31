using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public void OnMouseDown()
    {
        Game.Instance.OnSunClick();
        Destroy(gameObject);
    }
    
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0f, -1 * GameValues.SunSpeed, 0f));
        if(Game.Instance.IsRoundOver())
            Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
