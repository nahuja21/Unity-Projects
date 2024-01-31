using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutscene : MonoBehaviour
{
  // Time in seconds before the GameObject is deleted (length of video)
  private float deletionTime = 25f;

  // Start is called before the first frame update
  void Start()
  {
      // Start the coroutine to delete the GameObject after a specified time
      StartCoroutine(EndGameAfterCountdown());
  }

  // Coroutine to delete the GameObject after a specified time
  IEnumerator EndGameAfterCountdown()
  {
      // Wait for the specified time
      yield return new WaitForSeconds(deletionTime);

      // Destroy the GameObject after waiting
      Destroy(gameObject);

      // Check if the application is running in the Unity Editor
      #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
      #else
          // Quit the application in a standalone build
          Application.Quit();
      #endif
  }

}
