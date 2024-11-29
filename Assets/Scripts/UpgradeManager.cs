using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // Singleton
    public static UpgradeManager Instance { get; private set; }
    
    // Dependencies
    private SeedGatherer _seedGatherer;
    
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else // I am the instance now
        { 
            Instance = this; 
        } 
    }

    private void Start()
    {
        _seedGatherer = FindFirstObjectByType<SeedGatherer>();
    }

    public void UpgradeGatheringPower()
    {
        _seedGatherer.IncreaseGatherPower();
    }
}
