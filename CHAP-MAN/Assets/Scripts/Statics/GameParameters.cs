using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameParameters
{
    public const float pacmanMoveSpeed = 3f;
    public const float ghostMoveSpeed = 2f;
    public const float ghostVulnerableMoveSpeed = 1.5f;
    public const float ghostVulnerableDuration = 3f;
    public const float ghostRespawnTime = 8f;

    public const int nodeScoreValue = 15;
    public const int fruitScoreValue = 150;
    public const int ghostScoreValue = 250;
    public const int levelCompleteScoreValue = 500;

    public const int defaultLivesRemaining = 3;
}
