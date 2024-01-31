using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public SpriteRenderer CorgiSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 direction)
    {
        FaceCorrectDirection(direction);
        CorgiSpriteRenderer.transform.Translate(new
            Vector3(direction.x * GameParameters.CorgiMoveAmount,
                direction.y * GameParameters.CorgiMoveAmount,
                0f));
        KeepOnScreen();
    }

    private void KeepOnScreen()
    {
        CorgiSpriteRenderer.transform.position =
            SpriteTools.ConstrainToScreen(CorgiSpriteRenderer);
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        // if moving to the right
        if (direction.x > 0)
        {
            // face right
            CorgiSpriteRenderer.flipX = false;
        }
        else
        {
            // if moving to the left
            // face left
            CorgiSpriteRenderer.flipX = true;
        }
    }
}
