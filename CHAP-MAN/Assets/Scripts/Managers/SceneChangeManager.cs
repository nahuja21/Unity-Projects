using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scene switch script
public class SceneChangeManager : MonoBehaviour
{

    [SerializeField] private string mainMenuSceneName = "TitleScreen";
    [SerializeField] private string[] sceneLevelNames;

    public string GetNextLevelScene(string currLevelName)
    {

        Debug.Log("GetNewLevelSceneName called with" + currLevelName);

        switch (currLevelName)
        {
            case "Level_1":
                return "Level_2";

            case "Level_2":
                return "Level_3";

            case "Level_3":
                return "Level_4";

            case "Level_4":
                return "EndingScreen";

            default:
                return "Level_1";
        }
    }

    // Provide a name to switch scenes to in the script
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SwitchToMainMenuScene()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
