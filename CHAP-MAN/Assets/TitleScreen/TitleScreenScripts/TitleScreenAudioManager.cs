using UnityEngine;

public class TitleScreenAudioManager : MonoBehaviour
{
    public AudioSource audioSource; // Reference to your AudioSource component
    private bool isPlaying = false;

    void Start()
    {
        // Check if the AudioSource component is assigned
        if (audioSource != null)
        {
            // Invoke the PlayAudio method after 67 seconds
            Invoke("PlayAudio", 67f);
        }
        else
        {
            Debug.LogError("AudioSource component not assigned!");
        }
    }

    public void CutsceneSkipped(){
      PlayAudio();
    }

    void PlayAudio()
    {
        if (isPlaying == false){
          isPlaying = true;
          // Play the audio
          audioSource.Play();
        }
    }
}
