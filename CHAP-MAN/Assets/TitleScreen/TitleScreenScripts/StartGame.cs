using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Specify the name of the scene you want to load
    public string sceneToLoad = "Game";

    // This method is called when the associated button is clicked
    public void StartGameOnClick()
    {
        // Load the specified scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
