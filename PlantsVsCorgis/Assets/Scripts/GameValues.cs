using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameValues
{
    public static int PeaShooterSpawnTime = 3;
    public static float PeaSpeed = 0.01f;
    
    public static int BlueShooterSpawnTime = 2;

    public static float SunSpeed = 0.001f;

    public static List<int> SunSpawnTimeMinByLevel = new List<int>(){5, 2, 2};
    public static List<int> SunSpawnTimeMaxByLevel = new List<int>(){10, 5, 5};

    public static List<int> StartOfGameDelayByLevel = new List<int>(){8, 20, 20};
    public static List<int> CorgiSpawnTimeMinByLevel = new List<int>(){6, 7, 7};
    public static List<int> CorgiSpawnTimeMaxByLevel = new List<int>(){12, 16, 16};

    public static List<float> IntermediateCorgiSpawnChanceByLevel = new List<float>() { 10f, 25f, 30f };
    public static List<float> AdvancedCorgiSpawnChanceByLevel = new List<float>() { 1f, 20f, 25f };
    
    public static float CorgiSpeed = 0.0015f;
    
    public static int BasicCorgiHealth = 100;
    public static int IntermediateCorgiHealth = 200;
    public static int AdvancedCorgiHealth = 300;

    public static List<int> NumberCorgisPerLevel = new List<int>{7, 10, 13};

    public static float LawnmowerSpeed = 0.01f;

    // List of grass strip plant positions (x values)
    public static List<float> PlantGrassXPositions = new List<float>{-8f, -6f, -4f, -2f, 0f, 2f, 4f, 6f};
}
