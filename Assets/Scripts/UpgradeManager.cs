using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public void BuyFieldPlot()
    {
        if (!GameManager.Instance.fieldPlotManager.ActivateFieldPlot())
        {
            Debug.Log("No more field plot to buy");
        }
        
    }

    public void UpgradeGatheringPower()
    {
        GameManager.Instance.seedGatherer.IncreaseGatherPower();
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
