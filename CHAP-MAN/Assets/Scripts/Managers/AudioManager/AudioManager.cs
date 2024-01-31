using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AudioManager sub-singleton
public class AudioManager : MonoBehaviour
{   
    // Serialized Field of private audio sources for each channel.
    [SerializeField] private AudioSource musicAudioSource, playerAudioSource, worldAudioSource;

    // A bool to check if the son is playing. Used to play/pause the music
    private bool musicPlaying = false;

    // Method to play music from an audio clip provided from the button that activates it
    public void PlayMusic(AudioClip sound)
    {
        // Set the current song with the pushed sound
        musicAudioSource.clip = sound;
        if (musicPlaying == false)
        {
            musicAudioSource.Play();
        }
        else
        {
            musicAudioSource.Stop();
        }
        musicPlaying = !musicPlaying;
    }

    // Take a string that will determine which audio source to play the sound clip in.
    public void PlaySound(string audioClipType, AudioClip sound)
    {
        if (audioClipType.ToLower() == "player")
            playerAudioSource.PlayOneShot(sound);
        else if (audioClipType.ToLower() == "world")
            worldAudioSource.PlayOneShot(sound);
        else
            print("No clip played: Bad type");  // Prevents errors. Tells user in editor that a bad type was set
    }
}
