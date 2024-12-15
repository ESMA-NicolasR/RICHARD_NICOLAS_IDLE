using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeManager : MonoBehaviour
{
    private Dictionary<UpgradeEnum, Action> _upgradeEnumToAction;
    [SerializeField] private UpgradeReferences _upgradeReferences;

    private void Awake()
    {
        _upgradeEnumToAction = new Dictionary<UpgradeEnum, Action>()
        {
            { UpgradeEnum.UnlockFieldPlot, AddFieldPlot },
            { UpgradeEnum.UnlockShop, UnlockShop },
            { UpgradeEnum.UnlockCereal, UnlockCereal },
            { UpgradeEnum.UnlockFruit, UnlockFruit },
            { UpgradeEnum.UnlockVegetable, UnlockVegetable },
            { UpgradeEnum.UnlockAutoGather, UnlockAutoGather },
            { UpgradeEnum.AddFieldPlot, AddFieldPlot },
            { UpgradeEnum.GatherPowerOne, UpgradeGatherPowerOne },
            { UpgradeEnum.GatherPowerTen, UpgradeGatherPowerTen },
            { UpgradeEnum.AutoGatherSpeed, UpgradeAutoGatherSpeed },
            
        };
    }

    private void AddFieldPlot()
    {
        if (!GameManager.Instance.fieldPlotManager.ActivateFieldPlot())
        {
            Debug.Log("No more field plot to buy");
        }
        
    }

    private void UnlockShop()
    {
        _upgradeReferences.fieldPlotBuyer.SetActive(true);
        _upgradeReferences.firstShopUnlockBuyers.ForEach(value => value.SetActive(true));
    }

    private void UnlockCereal()
    {
        _upgradeReferences.cerealCounter.SetActive(true);
        if (_upgradeReferences.cerealUnlockedNb < _upgradeReferences.cerealUnlockers.Count)
        {
            _upgradeReferences.cerealUnlockers[_upgradeReferences.cerealUnlockedNb].SetActive(true);
            _upgradeReferences.cerealUnlockedNb++;
        }
        else
        {
            Debug.Log("No more cereal to unlock");
        }
    }
    
    private void UnlockFruit()
    {
        _upgradeReferences.fruitCounter.SetActive(true);
        if (_upgradeReferences.fruitUnlockedNb < _upgradeReferences.fruitUnlockers.Count)
        {
            _upgradeReferences.fruitUnlockers[_upgradeReferences.fruitUnlockedNb].SetActive(true);
            _upgradeReferences.fruitUnlockedNb++;
        }
        else
        {
            Debug.Log("No more fruit to unlock");
        }
    }
    
    private void UnlockVegetable()
    {
        _upgradeReferences.vegetableCounter.SetActive(true);
        if (_upgradeReferences.vegetableUnlockedNb < _upgradeReferences.vegetableUnlockers.Count)
        {
            _upgradeReferences.vegetableUnlockers[_upgradeReferences.vegetableUnlockedNb].SetActive(true);
            _upgradeReferences.vegetableUnlockedNb++;
        }
        else
        {
            Debug.Log("No more vegetable to unlock");
        }
    }

    private void UnlockAutoGather()
    {
        _upgradeReferences.autoGatherDisplay.SetActive(true);
        _upgradeReferences.autoGatherSpeedBuyer.SetActive(true);
        GameManager.Instance.autoGatherer.BeginAutoGathering();
    }

    private void UpgradeGatherPowerOne()
    {
        GameManager.Instance.seedGatherer.IncreaseGatherPower(1);
    }
    
    private void UpgradeGatherPowerTen()
    {
        GameManager.Instance.seedGatherer.IncreaseGatherPower(10);
    }

    private void UpgradeAutoGatherSpeed()
    {
        GameManager.Instance.autoGatherer.UpgradeAutoHarvestRate();
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
