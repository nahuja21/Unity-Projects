using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Quit Game Script to assign to a button to close the game in a build or editor
public class QuitCommand : MonoBehaviour
{
    public void QuitGame(){
        // Stop playmode on editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        // Close the game on built game
        Application.Quit();
    }
}
