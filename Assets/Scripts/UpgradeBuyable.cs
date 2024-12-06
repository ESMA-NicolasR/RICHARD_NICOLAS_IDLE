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
    [SerializeField] private MyDictionary<FoodTypeEnum, int> _foodCost;
    [SerializeField] private UnityEvent _onUpgrade;

    public void BuyUpgrade()
    {
        bool checkSeeds = SeedManager.Instance.CheckCanSpendSeed(_seedCost);
        bool checkFood = FoodManager.Instance.CheckCanSpendFood(_foodCost);

        if (checkFood && checkSeeds)
        {
            SeedManager.Instance.SpendSeeds(_seedCost);
            FoodManager.Instance.SpendFood(_foodCost);
            _onUpgrade.Invoke();
        }
        else
        {
            Debug.Log("Not enough seed or food");
        }
    }
}
