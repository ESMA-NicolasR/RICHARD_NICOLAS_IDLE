using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    // Singleton
    public static FoodManager Instance { get; private set; }
    
    // Gameplay
    private Dictionary<FoodTypeEnum, int> _foodStorage;
    
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
        _foodStorage = new Dictionary<FoodTypeEnum, int>();
        foreach (FoodTypeEnum foodType in Enum.GetValues(typeof(FoodTypeEnum)))
        {
            _foodStorage.Add(foodType, 0);
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

    public bool SpendFood(FoodTypeEnum foodTypeEnum, int nbSpend)
    {
        if (_foodStorage[foodTypeEnum] < nbSpend)
        {
            return false;
        }
        _foodStorage[foodTypeEnum] -= nbSpend;
        OnFoodAmountChanged?.Invoke(foodTypeEnum, _foodStorage[foodTypeEnum]);
        return true;
    }
}
