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
        bool checkSeeds = GameManager.Instance.seedManager.CheckCanSpendSeed(_seedCost);
        bool checkFood = GameManager.Instance.foodManager.CheckCanSpendFood(_foodCost);

        if (checkFood && checkSeeds)
        {
            GameManager.Instance.seedManager.SpendSeeds(_seedCost);
            GameManager.Instance.foodManager.SpendFood(_foodCost);
            _onUpgrade.Invoke();
        }
        else
        {
            Debug.Log("Not enough seed or food");
        }
    }
}
