using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeManager : MonoBehaviour
{
    public static Action OnUpgradeScalingChanged;
    private Dictionary<UpgradeEnum, Action> _upgradeEnumToAction;
    [SerializeField] private UpgradeReferences _upgradeReferences;
    private Dictionary<UpgradeScalingEnum, float> _upgradeScalings;

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
            { UpgradeEnum.AddCerealYield, AddCerealYield },
            { UpgradeEnum.ScaleGlobalYield, ScaleGLobalYield },
            { UpgradeEnum.AddFruitGrowSpeed, AddFruitSpeed },
            { UpgradeEnum.ScaleGlobalGrowSpeed, ScaleGlobalSpeed },
            { UpgradeEnum.AutomateHarvest, AutomateHarvest },
            { UpgradeEnum.ScaleWorldHungerReward, ScaleWorldHungerReward },
        };
        _upgradeScalings = new Dictionary<UpgradeScalingEnum, float>()
        {
            { UpgradeScalingEnum.AddCerealYield, 0f },
            { UpgradeScalingEnum.AddFruitGrowSpeed, 0f },
            { UpgradeScalingEnum.ExpGlobalYield, 0f },
            { UpgradeScalingEnum.ExpGlobalGrowSpeed, 0f },
            { UpgradeScalingEnum.MultWorldHungerReward, 1f },
        };
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
    
    public float GetScalingValue(UpgradeScalingEnum scaling)
    {
        if (_upgradeScalings.ContainsKey(scaling))
        {
            return _upgradeScalings[scaling];
        }
        
        Debug.Log("Scaling not initialized");
        return 0f;
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

    private void AddCerealYield()
    {
        _upgradeScalings[UpgradeScalingEnum.AddCerealYield] += 1f;
        OnUpgradeScalingChanged?.Invoke();
    }

    private void ScaleGLobalYield()
    {
        _upgradeScalings[UpgradeScalingEnum.ExpGlobalYield] += 0.2f;
        OnUpgradeScalingChanged?.Invoke();
    }
    
    private void AddFruitSpeed()
    {
        _upgradeScalings[UpgradeScalingEnum.AddFruitGrowSpeed] += 1f;
        OnUpgradeScalingChanged?.Invoke();
    }
    
    private void ScaleGlobalSpeed()
    {
        _upgradeScalings[UpgradeScalingEnum.ExpGlobalGrowSpeed] += 0.2f;
        OnUpgradeScalingChanged?.Invoke();
    }

    private void AutomateHarvest()
    {
        if (!GameManager.Instance.fieldPlotManager.AutomateFieldPlot())
        {
            Debug.Log("No more field plot to automate");
        }
    }
    
    private void ScaleWorldHungerReward()
    {
        _upgradeScalings[UpgradeScalingEnum.MultWorldHungerReward] += 0.5f;
        OnUpgradeScalingChanged?.Invoke();
    }
}
