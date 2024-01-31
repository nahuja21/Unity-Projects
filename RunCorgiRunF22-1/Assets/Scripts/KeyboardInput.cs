using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;

    public PoopPlacer PoopPlacer;
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            Corgi.Move(new Vector2(0f, 1f));
        }
        if (Input.GetKey(KeyCode.A))
        {
            Corgi.Move(new Vector2(-1f, 0f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Corgi.Move(new Vector2(1f, 0f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            Corgi.Move(new Vector2(0f, -1f));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PoopPlacer.Place(Corgi.CorgiSpriteRenderer.transform.position);
        }
    }
}
