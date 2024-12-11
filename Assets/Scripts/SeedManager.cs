using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    
    // Gameplay
    private int _nbSeeds;
    
    // Delegates
    public static event Action<int> OnNbSeedsChanged;
    
    private void Start()
    {
        OnNbSeedsChanged?.Invoke(_nbSeeds);
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

    public bool CheckCanSpendSeed(int nbSpend)
    {
        return _nbSeeds >= nbSpend;
    }

    public bool SpendSeeds(int nbSpend)
    {
        if (!CheckCanSpendSeed(nbSpend))
        {
            return false;
        }
        _nbSeeds -= nbSpend;
        OnNbSeedsChanged?.Invoke(_nbSeeds);
        return true;
    }
}
