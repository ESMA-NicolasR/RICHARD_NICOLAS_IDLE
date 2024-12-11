using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // Dependencies
    [SerializeField] private SeedGatherer _seedGatherer;
    
    private void Start()
    {
        _seedGatherer = FindFirstObjectByType<SeedGatherer>();
    }

    public void BuyFieldPlot()
    {
        if (!GameManager.Instance.fieldPlotManager.ActivateFieldPlot())
        {
            Debug.Log("No more field plot to buy");
        }
        
    }

    public void UpgradeGatheringPower()
    {
        _seedGatherer.IncreaseGatherPower();
    }

    public void UnlockUpgrade(UpgradeEnum upgrade)
    {
        switch (upgrade)
        {
            case UpgradeEnum.UnlockFieldPlot:
                BuyFieldPlot();
                break;
            case UpgradeEnum.UnlockAutoHarvest:
                break;
        }
    }
}
