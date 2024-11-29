using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    // Singleton
    public static SeedManager Instance { get; private set; }
    
    // Gameplay
    private int _nbSeeds;
    
    // Delegates
    public static event Action<int> OnNbSeedsChanged;
    
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int GetSeedNb()
    {
        return _nbSeeds;
    }

    public void AddSeeds(int nbAdd)
    {
        _nbSeeds += nbAdd;
        OnNbSeedsChanged?.Invoke(_nbSeeds);
    }

    public bool SpendSeeds(int nbSpend)
    {
        if (_nbSeeds < nbSpend)
        {
            return false;
        }
        _nbSeeds -= nbSpend;
        OnNbSeedsChanged?.Invoke(_nbSeeds);
        return true;
    }
}
