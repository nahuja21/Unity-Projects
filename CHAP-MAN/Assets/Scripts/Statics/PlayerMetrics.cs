using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerMetrics
{
    public static int totalScore;
    public static int currentLevel;
    public static int livesRemaining;

    public static void AddScore(int amount) => totalScore += amount;
    public static void AddLevel() => currentLevel += 1; 
    public static void AddLife() => livesRemaining += 1;

    public static void Reset()
    {
        totalScore = 0;
        currentLevel = 0;
        livesRemaining = GameParameters.defaultLivesRemaining;
    }

    public static void SaveMetrics() { }
}
