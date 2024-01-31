using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Master singleton class
public class Singleton : MonoBehaviour
{
    // Code provided by Unity API
    public static Singleton Instance { get; private set; }  // Auto-Implemented Property
    public AudioManager AudioManager { get; private set; }  // Audio Manager Singleton
    public GameManager GameManager { get; private set; }  // Game Manager Singleton
    public SceneChangeManager SceneManager { get; private set; }  // Scene Manager Singleton

    private void Awake()
    {
        if (Instance != null && Instance!= this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            
            Debug.Log("Instance was assigned to this!");
            
            AudioManager = GetComponentInChildren<AudioManager>();
            GameManager = GetComponentInChildren<GameManager>();
            SceneManager = GetComponentInChildren<SceneChangeManager>();
            
            Debug.Log(GameManager);
        }
    }

}
