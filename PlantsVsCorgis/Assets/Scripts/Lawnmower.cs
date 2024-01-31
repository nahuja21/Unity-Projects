using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lawnmower : MonoBehaviour
{
    public GameObject SunPrefab;

    private bool ShouldLawnmowerMove = false;

    private void Start()
    {
        Physics2D.IgnoreCollision(SunPrefab.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
    }

    private void Update()
    {
        if(ShouldLawnmowerMove)
            gameObject.transform.Translate(new Vector3(1 * GameValues.LawnmowerSpeed, 0f, 0f));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "corgi")
        {
            ShouldLawnmowerMove = true;
            Sounds.Instance.PlayLawnMowerClip();
        }
    }

    private void OnBecameInvisible()
    {
        ShouldLawnmowerMove = false;
        Destroy(gameObject);
    }
}
