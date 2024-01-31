using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip LawnMowerClip;
    public AudioClip CorgiBeingHitClip;
    public AudioClip SunClip;
    public AudioClip PlantSpawn;
    public AudioClip GameOverClip;

    public static Sounds Instance;
    
    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }
    public void PlayGameOverClip()
    {
        AudioSource.PlayOneShot(GameOverClip);
    }
    public void PlayLawnMowerClip()
    {
        AudioSource.PlayOneShot(LawnMowerClip);
    }
    public void PlayPlantSpawn()
    {
        AudioSource.PlayOneShot(PlantSpawn);
    }
    public void PlayCorgiBeingHitClip()
    {
        AudioSource.PlayOneShot(CorgiBeingHitClip);
    }
    public void PlaySunClip()
    {
        AudioSource.PlayOneShot(SunClip);
    }
}
