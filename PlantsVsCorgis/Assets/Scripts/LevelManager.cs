using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GrassStrip GetGrassStrip()
    {
        return gameObject.GetComponentInChildren<GrassStrip>();
    }

    public void DeleteLevelInstance()
    {
        Destroy(gameObject);
    }
}
