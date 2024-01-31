using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // This method is called when the associated button is clicked
    public void QuitGameOnClick()
    {
        // Check if the application is running in the Unity Editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Quit the application in a standalone build
            Application.Quit();
        #endif
    }
}
