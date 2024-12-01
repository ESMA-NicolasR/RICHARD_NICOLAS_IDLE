using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeBuyable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _upgradeText;
    [SerializeField] private int _seedCost;
    [SerializeField] private FoodHolder _foodCost;
    [SerializeField] private UnityEvent _onUpgrade;

    public void BuyUpgrade()
    {
        bool checkSeeds = SeedManager.Instance.SpendSeeds(_seedCost);
        bool checkFood = true;
        Dictionary<FoodTypeEnum, int> foodCostAsDict = _foodCost.GetValuesAsDict();
        foreach (FoodTypeEnum foodType in foodCostAsDict.Keys)
        {
            checkFood &= FoodManager.Instance.SpendFood(foodType, foodCostAsDict[foodType]);
        }

        if (checkFood && checkSeeds)
        {
            _onUpgrade.Invoke();
        }
        else
        {
            Debug.Log("Not enough seed or food");
        }
    }
}
