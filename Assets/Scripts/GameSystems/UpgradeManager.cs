using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // Delegates
    public static event Action OnUpgradeScalingChanged;
    // Gameplay
    private Dictionary<UpgradeEnum, Action> _upgradeEnumToAction;
    [SerializeField] private UpgradeReferences _upgradeReferences;
    private Dictionary<UpgradeScalingEnum, float> _upgradeScalings;
    // Tweaking
    private const float BONUS_CEREAL_YIELD = 1f;
    private const float BONUS_GLOBAL_YIELD = 0.2f;
    private const float BONUS_FRUIT_SPEED = 0.5f;
    private const float BONUS_GLOBAL_SPEED = 0.2f;
    private const float BONUS_WORLD_HUNGER = 0.5f;
    private const long BONUS_GATHER_POWER_ONE = 1;
    private const long BONUS_GATHER_POWER_TEN = 10;

    private void Awake()
    {
        _upgradeEnumToAction = new Dictionary<UpgradeEnum, Action>()
        {
            { UpgradeEnum.UnlockFieldPlot, UnlockFieldPlot },
            { UpgradeEnum.UnlockShop, UnlockShop },
            { UpgradeEnum.UnlockCereal, UnlockCereal },
            { UpgradeEnum.UnlockFruit, UnlockFruit },
            { UpgradeEnum.UnlockVegetable, UnlockVegetable },
            { UpgradeEnum.UnlockCerealUpgrades, UnlockCerealUpgrades },
            { UpgradeEnum.UnlockFruitUpgrades, UnlockFruitUpgrades },
            { UpgradeEnum.UnlockVegetableUpgrades, UnlockVegetableUpgrades },
            { UpgradeEnum.UnlockAutoGather, UnlockAutoGather },
            { UpgradeEnum.AddFieldPlot, AddFieldPlot },
            { UpgradeEnum.GatherPowerOne, UpgradeGatherPowerOne },
            { UpgradeEnum.GatherPowerTen, UpgradeGatherPowerTen },
            { UpgradeEnum.AutoGatherSpeed, UpgradeAutoGatherSpeed },
            { UpgradeEnum.AddCerealYield, AddCerealYield },
            { UpgradeEnum.ScaleGlobalYield, ScaleGlobalYield },
            { UpgradeEnum.AddFruitGrowSpeed, AddFruitSpeed },
            { UpgradeEnum.ScaleGlobalGrowSpeed, ScaleGlobalSpeed },
            { UpgradeEnum.AutomateHarvest, AutomateHarvest },
            { UpgradeEnum.ScaleWorldHungerReward, ScaleWorldHungerReward },
        };
        _upgradeScalings = new Dictionary<UpgradeScalingEnum, float>()
        {
            { UpgradeScalingEnum.AddCerealYield, 0f },
            { UpgradeScalingEnum.AddFruitGrowSpeed, 0f },
            { UpgradeScalingEnum.MultGlobalYield, 1f },
            { UpgradeScalingEnum.ExpGlobalGrowSpeed, 0f },
            { UpgradeScalingEnum.MultWorldHungerReward, 1f },
        };
    }

    public void UnlockFieldPlot()
    {
        _upgradeReferences.fieldPlotBuyer.SetActive(true);
        _upgradeReferences.fieldPlotBuyer.GetComponent<UpgradeBuyer>().UpdateDisplay();
        AddFieldPlot();
    }
    
    public void UnlockUpgrade(UpgradeEnum upgrade)
    {
        if (_upgradeEnumToAction.ContainsKey(upgrade))
        {
            _upgradeEnumToAction[upgrade].Invoke();
        }
        else
        {
            Debug.LogError("Upgrade not found");
        }
    }
    
    public float GetScalingValue(UpgradeScalingEnum scaling)
    {
        if (_upgradeScalings.ContainsKey(scaling))
        {
            return _upgradeScalings[scaling];
        }
        
        Debug.LogError("Scaling not initialized");
        return 0f;
    }

    private void AddFieldPlot()
    {
        if (!GameManager.Instance.fieldPlotManager.ActivateFieldPlot())
        {
            Debug.LogError("No more field plot to buy");
        }
        
    }

    private void UnlockShop()
    {
        _upgradeReferences.firstShopUnlockBuyers.ForEach(value => value.Unlock());
    }

    private void UnlockCereal()
    {
        _upgradeReferences.cerealCounter.SetActive(true);
        if (_upgradeReferences.cerealUnlockedNb < _upgradeReferences.cerealPlanters.Count)
        {
            _upgradeReferences.cerealPlanters[_upgradeReferences.cerealUnlockedNb].Unlock();
            _upgradeReferences.cerealUnlockedNb++;
        }
        else
        {
            Debug.LogError("No more cereal to unlock");
        }
    }
    
    private void UnlockFruit()
    {
        _upgradeReferences.fruitCounter.SetActive(true);
        if (_upgradeReferences.fruitUnlockedNb < _upgradeReferences.fruitPlanters.Count)
        {
            _upgradeReferences.fruitPlanters[_upgradeReferences.fruitUnlockedNb].Unlock();
            _upgradeReferences.fruitUnlockedNb++;
        }
        else
        {
            Debug.LogError("No more fruit to unlock");
        }
    }
    
    private void UnlockVegetable()
    {
        _upgradeReferences.vegetableCounter.SetActive(true);
        if (_upgradeReferences.vegetableUnlockedNb < _upgradeReferences.vegetablePlanters.Count)
        {
            _upgradeReferences.vegetablePlanters[_upgradeReferences.vegetableUnlockedNb].Unlock();
            _upgradeReferences.vegetableUnlockedNb++;
        }
        else
        {
            Debug.LogError("No more vegetable to unlock");
        }
    }

    private void UnlockCerealUpgrades()
    {
        _upgradeReferences.cerealUpgrades.ForEach(value => value.Unlock());
    }
    
    private void UnlockFruitUpgrades()
    {
        _upgradeReferences.fruitUpgrades.ForEach(value => value.Unlock());
    }
    
    private void UnlockVegetableUpgrades()
    {
        _upgradeReferences.vegetableUpgrades.ForEach(value => value.Unlock());
    }

    private void UnlockAutoGather()
    {
        _upgradeReferences.autoGatherDisplay.SetActive(true);
        _upgradeReferences.autoGatherSpeedBuyer.SetActive(true);
        GameManager.Instance.autoGatherer.BeginAutoGathering();
    }

    private void UpgradeGatherPowerOne()
    {
        GameManager.Instance.seedGatherer.IncreaseGatherPower(BONUS_GATHER_POWER_ONE);
    }
    
    private void UpgradeGatherPowerTen()
    {
        GameManager.Instance.seedGatherer.IncreaseGatherPower(BONUS_GATHER_POWER_TEN);
    }

    private void UpgradeAutoGatherSpeed()
    {
        GameManager.Instance.autoGatherer.UpgradeAutoHarvestRate();
    }

    private void AddCerealYield()
    {
        _upgradeScalings[UpgradeScalingEnum.AddCerealYield] += BONUS_CEREAL_YIELD;
        OnUpgradeScalingChanged?.Invoke();
    }

    private void ScaleGlobalYield()
    {
        _upgradeScalings[UpgradeScalingEnum.MultGlobalYield] += BONUS_GLOBAL_YIELD;
        OnUpgradeScalingChanged?.Invoke();
    }
    
    private void AddFruitSpeed()
    {
        _upgradeScalings[UpgradeScalingEnum.AddFruitGrowSpeed] += BONUS_FRUIT_SPEED;
        OnUpgradeScalingChanged?.Invoke();
    }
    
    private void ScaleGlobalSpeed()
    {
        _upgradeScalings[UpgradeScalingEnum.ExpGlobalGrowSpeed] += BONUS_GLOBAL_SPEED;
        OnUpgradeScalingChanged?.Invoke();
    }

    private void AutomateHarvest()
    {
        if (!GameManager.Instance.fieldPlotManager.AutomateFieldPlot())
        {
            Debug.LogError("No more field plot to automate");
        }
    }
    
    private void ScaleWorldHungerReward()
    {
        _upgradeScalings[UpgradeScalingEnum.MultWorldHungerReward] += BONUS_WORLD_HUNGER;
        OnUpgradeScalingChanged?.Invoke();
    }
}
