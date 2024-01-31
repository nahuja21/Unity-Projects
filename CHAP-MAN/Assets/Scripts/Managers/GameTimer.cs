using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public Text countdownText;
    // A Coroutine that performs a countdown to start a game with a given amount of seconds.
    public IEnumerator GameCountdown()
    {
        // Each level duration will be set to 200 seconds
        int duration = 200;
        string currentStatus;
        countdownText.gameObject.SetActive(true);
        // Count down each second until the countdown reaches 0.
        while (duration > 0)
        {
            currentStatus = "TIME\n" + duration.ToString();   // Update current duration text
            countdownText.text = currentStatus;
            yield return new WaitForSeconds(1);
            duration--;
        }
        countdownText.text = "DEAD";  // Replace 0's status with Go!
        yield return new WaitForSeconds(1);
        countdownText.gameObject.SetActive(false);
        FindObjectOfType<LevelManager>().EndLevel(false);
    }
}
