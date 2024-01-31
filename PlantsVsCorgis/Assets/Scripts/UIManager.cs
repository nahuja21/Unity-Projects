using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class UIManager : MonoBehaviour
{
    public Text SunCountText;
    public Text GameOverText;
    public Image PeaShooterCard;
    public Image BlueShooterCard;
    public Image SunFlowerCard;
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverScreenCanvasGroup;
    public CanvasGroup RoundOverScreenCanvasGroup;
    public Text RoundOverButtonText;

    public void Reset()
    {
        UpdateSunCountText(50);
        HidePeaShooterCard();
        HideBlueShooterCard();
    }

    public void UpdateSunCountText(int sunCount)
    {
        SunCountText.text = sunCount.ToString();
    }

    public void HidePeaShooterCard()
    {
        PeaShooterCard.enabled = false;
    }
    
    public void HideBlueShooterCard()
    {
        BlueShooterCard.enabled = false;
    }
    
    public void HideSunFlowerCard()
    {
        SunFlowerCard.enabled = false;
    }
    
    public void ShowPeaShooterCard()
    {
        PeaShooterCard.enabled = true;
    }
    
    public void ShowBlueShooterCard()
    {
        BlueShooterCard.enabled = true;
    }
    
    public void ShowSunFlowerCard()
    {
        SunFlowerCard.enabled = true;
    }

    public void HideStartScreen()
    {
        StartScreenCanvasGroup.alpha = 0;
        StartScreenCanvasGroup.blocksRaycasts = false;
    }

    public void HideGameOverScreen()
    {
        GameOverScreenCanvasGroup.alpha = 0;
        GameOverScreenCanvasGroup.blocksRaycasts = false;
    }

    public void ShowGameOverWinScreen()
    {
        GameOverText.text = "You Win!";
        GameOverScreenCanvasGroup.alpha = 1;
        GameOverScreenCanvasGroup.blocksRaycasts = true;
    }
    
    public void ShowGameOverLostScreen()
    {
        GameOverText.text = "You Lost!";
        GameOverScreenCanvasGroup.alpha = 1;
        GameOverScreenCanvasGroup.blocksRaycasts = true;
    }

    public void ShowRoundOverScreen(int roundNum)
    {
        RoundOverButtonText.text = "Play Round " + roundNum;
        RoundOverScreenCanvasGroup.alpha = 1;
        RoundOverScreenCanvasGroup.blocksRaycasts = true;
    }
    
    public void HideRoundOverScreen()
    {
        RoundOverScreenCanvasGroup.alpha = 0;
        RoundOverScreenCanvasGroup.blocksRaycasts = false;
    }
}
