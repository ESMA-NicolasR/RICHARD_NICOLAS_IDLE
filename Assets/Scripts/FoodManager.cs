using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    // Singleton
    public static FoodManager Instance { get; private set; }
    
    // Gameplay
    [SerializeField] private MyDictionary<FoodTypeEnum, int> _foodStorage;
    
    // Delegates
    public static event Action<FoodTypeEnum, int> OnFoodAmountChanged;
    
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else // I am the instance now
        { 
            Instance = this; 
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        _foodStorage = new MyDictionary<FoodTypeEnum, int>();
        foreach (FoodTypeEnum foodType in Enum.GetValues(typeof(FoodTypeEnum)))
        {
            _foodStorage.Add(foodType, 0);
            OnFoodAmountChanged?.Invoke(foodType, _foodStorage[foodType]);
        }
    }
    
    public int GetFoodAmount(FoodTypeEnum foodTypeEnum)
    {
        return _foodStorage[foodTypeEnum];
    }

    public void AddFood(FoodTypeEnum foodTypeEnum, int nbAdd)
    {
        _foodStorage[foodTypeEnum] += nbAdd;
        OnFoodAmountChanged?.Invoke(foodTypeEnum, _foodStorage[foodTypeEnum]);
    }
    

    public bool CheckCanSpendFood(FoodTypeEnum foodTypeEnum, int nbSpend)
    {
        return _foodStorage[foodTypeEnum] >= nbSpend;
    }

    public bool CheckCanSpendFood(MyDictionary<FoodTypeEnum, int> foodCost)
    {
        bool canSpend = true;
        
        foodCost.ForEach((key, value) => canSpend &= CheckCanSpendFood(key, value));

        return canSpend;
    }
    
    public bool SpendFood(FoodTypeEnum foodTypeEnum, int nbSpend)
    {
        if (!CheckCanSpendFood(foodTypeEnum, nbSpend))
        {
            return false;
        }
        _foodStorage[foodTypeEnum] -= nbSpend;
        OnFoodAmountChanged?.Invoke(foodTypeEnum, _foodStorage[foodTypeEnum]);
        return true;
    }

    public bool SpendFood(MyDictionary<FoodTypeEnum, int> foodCost)
    {
        if (!CheckCanSpendFood(foodCost))
        {
            return false;
        }
        foodCost.ForEach((key, value) => SpendFood(key, value));
        
        return true;
    }
}
