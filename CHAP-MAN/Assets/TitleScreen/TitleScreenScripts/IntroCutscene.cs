using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
  // Time in seconds before the GameObject is deleted (length of video)
  private float deletionTime = 71f;

  // Start is called before the first frame update
  void Start()
  {
      // Start the coroutine to delete the GameObject after a specified time
      StartCoroutine(DeleteAfterTimeCoroutine());
  }

  // Coroutine to delete the GameObject after a specified time
  IEnumerator DeleteAfterTimeCoroutine()
  {
      // Wait for the specified time
      yield return new WaitForSeconds(deletionTime);

      // Destroy the GameObject after waiting
      Destroy(gameObject);
  }

  public void DeleteImmidiate(){
    Destroy(gameObject);
  }
}
