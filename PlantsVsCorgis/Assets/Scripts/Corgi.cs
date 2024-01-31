using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    protected int health;

    void Update()
    {
        gameObject.transform.Translate(new Vector3(-1 * GameValues.CorgiSpeed, 0f, 0f));
        if(Game.Instance.IsRoundOver())
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Pea")
        {
            Destroy(col.gameObject);
            Sounds.Instance.PlayCorgiBeingHitClip();
            health -= 34;
            if (health <= 0)
            {
                gameObject.GetComponentInParent<GrassStrip>().DeleteCorgi(gameObject);
                Destroy(gameObject);
                Game.Instance.CorgiDestroyed();
            }
        }
        else if (col.gameObject.tag == "Lawnmower")
        {
            gameObject.GetComponentInParent<GrassStrip>().DeleteCorgi(gameObject);
            Destroy(gameObject);
            Game.Instance.CorgiDestroyed();
        }
        else if (col.gameObject.tag == "barrier")
        {
            Game.Instance.LostGame();
        }
        else if (col.gameObject.tag == "Plant")
        {
            gameObject.GetComponentInParent<GrassStrip>().DeletePlant(col.gameObject);
            Destroy(col.gameObject);
        }
    }
}

