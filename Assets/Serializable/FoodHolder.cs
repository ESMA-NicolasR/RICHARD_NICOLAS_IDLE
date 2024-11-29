using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FoodQuantity
{
    public int amount;
    public FoodType foodType;
}

[Serializable]
public class FoodHolder
{
    [SerializeField] private List<FoodQuantity> _food;

    public Dictionary<FoodType, int> GetValuesAsDict()
    {
        Dictionary<FoodType, int> values = new Dictionary<FoodType, int>();
        foreach (FoodQuantity food in _food)
        {
            values.Add(food.foodType, food.amount);
        }
        return values;
    }
}