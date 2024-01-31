using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Audio player script that allows for a button to hold and push an audio clip to be played from the audio manager
public class AudioPlayer : MonoBehaviour
{
    // Attach an audio clip to play
    [SerializeField] private AudioClip clipToPlay;
    public void playMusic()
    {
        Singleton.Instance.AudioManager.PlayMusic(clipToPlay);
    }

    public void playSound(string audioClipType)
    {
        Singleton.Instance.AudioManager.PlaySound(audioClipType, clipToPlay);
    }
}
