using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class FoodQuantity
{
    public int amount;
    [FormerlySerializedAs("foodType")] public FoodTypeEnum foodTypeEnum;
}

[Serializable]
public class FoodHolder
{
    [SerializeField] private List<FoodQuantity> _food;

    public Dictionary<FoodTypeEnum, int> GetValuesAsDict()
    {
        Dictionary<FoodTypeEnum, int> values = new Dictionary<FoodTypeEnum, int>();
        foreach (FoodQuantity food in _food)
        {
            values.Add(food.foodTypeEnum, food.amount);
        }
        return values;
    }
}