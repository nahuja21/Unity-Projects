using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // Player Input
    [SerializeField] public PlayerInput playerInput;

    // States
    public GameStateMachine stateMachine;

    public GameMainMenuState mainMenuState;

    public GamePausedState pausedState;
    public GamePlayingState playingState;

    // Gameplay
    private string currLevelName = "Level_1";

    private void Start()
    {
        this.stateMachine = new GameStateMachine();

        this.mainMenuState = new GameMainMenuState(this, stateMachine, "MainMenu");

        this.pausedState = new GamePausedState(this, stateMachine, "Paused");
        this.playingState = new GamePlayingState(this, stateMachine, "Playing");

        stateMachine.Initialize(mainMenuState);
    }

    private void Update()
    {
        stateMachine.currentState.HandleInput();
        stateMachine.currentState.LogicUpdate();

        if (Input.GetKeyDown(KeyCode.P)) FindObjectOfType<LevelManager>().nodesRemaining = 0;
    }

    public void StartGame()
    {
        Singleton.Instance.SceneManager.SwitchScene(currLevelName);

        stateMachine.ChangeState(playingState);

        UnpauseTimeScale();
    }

    public void GoToNextLevel()
    {
        PlayerMetrics.AddLevel();

        UnpauseTimeScale();

        currLevelName = Singleton.Instance.SceneManager.GetNextLevelScene(currLevelName);
        Debug.Log(currLevelName);
        Singleton.Instance.SceneManager.SwitchScene(currLevelName);
    }

    public void LevelComplete(int levelScore, bool won)
    {
        PlayerMetrics.AddScore(levelScore);
        PlayerMetrics.AddLife();

        if (won) FindObjectOfType<GameUIManager>().ToggleWinLevelPanel(true);
        else FindObjectOfType<GameUIManager>().ToggleLoseLevelPanel(true);

        PauseTimeScale();
    }

    public void EndGame()
    {
        PlayerMetrics.SaveMetrics();
        PlayerMetrics.Reset();

        stateMachine.ChangeState(mainMenuState);

        Singleton.Instance.SceneManager.SwitchToMainMenuScene();
        currLevelName = "Level_1";
    }

    public void PauseGame()
    {
        PauseTimeScale();

        FindObjectOfType<GameUIManager>().TogglePausePanel(true);
    }

    public void UnpauseGame()
    {
        UnpauseTimeScale();

        FindObjectOfType<GameUIManager>().TogglePausePanel(false);
    }

    void PauseTimeScale() => Time.timeScale = 0f;

    void UnpauseTimeScale() => Time.timeScale = 1f;

}
