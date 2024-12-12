using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance { get; private set; }
    
    // Dependencies
    [NonSerialized] public UpgradeManager upgradeManager;
    [NonSerialized] public ResourceManager resourceManager;
    [NonSerialized] public FieldPlotManager fieldPlotManager;
    [NonSerialized] public TaskManager taskManager;
    [NonSerialized] public SeedGatherer seedGatherer;
    [NonSerialized] public AutoGatherer autoGatherer;
    
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself
        if (Instance != null && Instance != this) 
        { 
            Destroy(gameObject); 
        } 
        else // I am the instance now
        { 
            Instance = this; 
        }
        
        // Search dependencies on gameObject
        upgradeManager = GetComponent<UpgradeManager>();
        resourceManager = GetComponent<ResourceManager>();
        fieldPlotManager = GetComponent<FieldPlotManager>();
        taskManager = GetComponent<TaskManager>();
        seedGatherer = GetComponent<SeedGatherer>();
        seedGatherer = GetComponent<SeedGatherer>();
    }
}
