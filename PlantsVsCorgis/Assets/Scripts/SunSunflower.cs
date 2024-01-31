using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSunflower : MonoBehaviour
{
    private void Update()
    {
        if(Game.Instance.IsRoundOver())
            Destroy(gameObject);
    }
    
    public void OnMouseDown()
    {
        Game.Instance.OnSunClick();
        Destroy(gameObject);
    }
}
