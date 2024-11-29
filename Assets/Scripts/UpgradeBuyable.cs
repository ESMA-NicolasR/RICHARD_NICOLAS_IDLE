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
    [SerializeField] private Dictionary<FoodType, int> _foodCost;
    [SerializeField] private UnityEvent _onUpgrade;

    public bool testFood;

    private void Start()
    {
        _foodCost = new Dictionary<FoodType, int>();
        foreach (FoodType foodType in Enum.GetValues(typeof(FoodType)))
        {
            _foodCost.Add(foodType, 0);
        }

        if (testFood)
        {
            _foodCost[FoodType.Cereal] = 1;
            _foodCost[FoodType.Fruit] = 3;
        }
    }

    public void BuyUpgrade()
    {
        bool checkSeeds = SeedManager.Instance.SpendSeeds(_seedCost);
        bool checkFood = true;
        foreach (FoodType foodType in _foodCost.Keys)
        {
            checkFood &= FoodManager.Instance.SpendFood(foodType, _foodCost[foodType]);
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
