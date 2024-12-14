using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeManager : MonoBehaviour
{
    private Dictionary<UpgradeEnum, Action> _upgradeEnumToAction;

    private void Awake()
    {
        _upgradeEnumToAction = new Dictionary<UpgradeEnum, Action>()
        {
            { UpgradeEnum.UnlockFieldPlot, BuyFieldPlot },
            { UpgradeEnum.AddFieldPlot, BuyFieldPlot },
            { UpgradeEnum.GatherPowerOne, UpgradeGatherPowerOne },
            { UpgradeEnum.GatherPowerTen, UpgradeGatherPowerTen },
            
        };
    }

    public void BuyFieldPlot()
    {
        if (!GameManager.Instance.fieldPlotManager.ActivateFieldPlot())
        {
            Debug.Log("No more field plot to buy");
        }
        
    }

    public void UpgradeGatherPowerOne()
    {
        GameManager.Instance.seedGatherer.IncreaseGatherPower(1);
    }
    
    public void UpgradeGatherPowerTen()
    {
        GameManager.Instance.seedGatherer.IncreaseGatherPower(10);
    }

    public void UnlockUpgrade(UpgradeEnum upgrade)
    {
        if (_upgradeEnumToAction.ContainsKey(upgrade))
        {
            _upgradeEnumToAction[upgrade].Invoke();
        }
        else
        {
            Debug.Log("Upgrade not found");
        }
    }
}
