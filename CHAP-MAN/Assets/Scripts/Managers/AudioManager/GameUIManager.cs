using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameObject winLevelPanel;
    public TextMeshProUGUI winLevelTotalScoreText;
    public TextMeshProUGUI winLevelLevelScoreText;
    [Space]
    public GameObject loseLevelPanel;
    public TextMeshProUGUI loseLevelTotalScoreText;
    public TextMeshProUGUI loseLevelLevelScoreText;
    [Space]
    public GameObject gamePausedPanel;
    public TextMeshProUGUI gamePausedLevelScoreText;
    
    private Pacman pacman;

    void Start()
    {
        pacman = FindObjectOfType<Pacman>();
        StartCoroutine(this.GetComponent<GameTimer>().GameCountdown());
    }

    public void OnClickGoToMainMenu()
    {
        Singleton.Instance.GameManager.EndGame();
    }

    public void OnClickGoToNextLevel()
    {
        Debug.Log("Going next level");
        Singleton.Instance.GameManager.GoToNextLevel();
    }

    public void ToggleWinLevelPanel(bool state)
    {
        winLevelPanel.SetActive(state);
        winLevelTotalScoreText.text = $"Total Score: {PlayerMetrics.totalScore.ToString()}";
        winLevelLevelScoreText.text = $"Level Score: {FindObjectOfType<LevelManager>().levelScore.ToString()}";
        pacman.StopMoving();

    }

    public void ToggleLoseLevelPanel(bool state)
    {
        loseLevelPanel.SetActive(state);
        loseLevelTotalScoreText.text = $"Total Score: {PlayerMetrics.totalScore.ToString()}";
        loseLevelLevelScoreText.text = $"Level Score: {FindObjectOfType<LevelManager>().levelScore.ToString()}";
        pacman.StopMoving();
    }

    public void TogglePausePanel(bool state)
    {
        gamePausedPanel.SetActive(state);
        gamePausedLevelScoreText.text = $"Level Score: {FindObjectOfType<LevelManager>().levelScore.ToString()}";
        pacman.StopMoving();
    }
}
