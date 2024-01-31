using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public List<GameObject> levels;
    public UIManager UIManager;
    public GameObject Sun;
    public static Game Instance;
    public Sounds Sounds;
    protected bool isRoundOver = true;

    private int currentLevel = 0;
    private GameObject currentLevelObject;
    private int sunCount = 50;
    
    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }
    
    void Start()
    {
        StartCoroutine(SpawnSun());
    }

    public void Reset()
    {
        UIManager.Reset();
        sunCount = 50;
        isRoundOver = false;
        UpdateUIAfterSunChange();
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void StartGame()
    {
        Reset();
        currentLevelObject = Instantiate(levels[currentLevel], levels[currentLevel].transform.position, Quaternion.identity);
        currentLevelObject.transform.SetParent(gameObject.transform);
        UIManager.HideStartScreen();
        UIManager.HideGameOverScreen();
        UIManager.HideRoundOverScreen();
    }

    IEnumerator SpawnSun()
    {
        yield return new WaitForSeconds(Random.Range(GameValues.SunSpawnTimeMinByLevel[currentLevel], GameValues.SunSpawnTimeMaxByLevel[currentLevel]));
        if(!isRoundOver)
            Instantiate(Sun, SpriteTools.RandomTopOfScreenWorldLocation(), Quaternion.identity);
        StartCoroutine(SpawnSun());
    }

    public void OnSunClick()
    {
        sunCount += 25;
        UpdateUIAfterSunChange();
        Sounds.PlaySunClip();
    }
    
    private void UpdateUIAfterSunChange()
    {
        UIManager.UpdateSunCountText(sunCount);
        if (sunCount >= 175) {
            UIManager.ShowSunFlowerCard();
            UIManager.ShowBlueShooterCard();
            UIManager.ShowPeaShooterCard();
        } else if (sunCount >= 100) {
            UIManager.ShowPeaShooterCard();
            UIManager.ShowSunFlowerCard();
            UIManager.HideBlueShooterCard();
        } else if (sunCount >= 50) {
            UIManager.HidePeaShooterCard();
            UIManager.ShowSunFlowerCard();
            UIManager.HideBlueShooterCard();
        } else {
            UIManager.HidePeaShooterCard();
            UIManager.HideSunFlowerCard();
            UIManager.HideBlueShooterCard();
        }
    }

    public void DecreaseSunCount(int amount)
    {
        sunCount -= amount;
        UpdateUIAfterSunChange();
    }

    public bool CheckIfAllCorgisAreEliminated()
    {
        bool isGameOver = true;
        GrassStrip[] grassStrips = gameObject.GetComponentsInChildren<GrassStrip>();
        foreach (GrassStrip grass in grassStrips)
        {
            if (!grass.AreAllCorgisDefeated())
                isGameOver = false;
        }

        return isGameOver;
    }

    public bool IsRoundOver()
    {
        return isRoundOver;
    }

    public void CorgiDestroyed()
    {
        isRoundOver = CheckIfAllCorgisAreEliminated();
        if (isRoundOver && currentLevel+1 >= levels.Count)
        {
            currentLevel = 0;
            UIManager.ShowGameOverWinScreen();
            Destroy(currentLevelObject);
        }
        else if (isRoundOver && currentLevel+1 < levels.Count)
        {
            currentLevel++;
            UIManager.ShowRoundOverScreen(currentLevel + 1);
            Destroy(currentLevelObject);
        }
    }

    public void LostGame()
    {
        currentLevel = 0;
        UIManager.ShowGameOverLostScreen();
        isRoundOver = true;
        Destroy(currentLevelObject);
        Sounds.Instance.PlayGameOverClip();
    }
}
