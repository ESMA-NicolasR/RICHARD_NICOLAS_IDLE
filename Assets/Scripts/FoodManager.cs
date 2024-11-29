using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    // Singleton
    public static FoodManager Instance { get; private set; }
    
    // Gameplay
    private Dictionary<FoodType, int> _foodStorage;
    
    // Delegates
    public static event Action<FoodType, int> OnFoodAmountChanged;
    
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
        _foodStorage = new Dictionary<FoodType, int>();
        foreach (FoodType foodType in Enum.GetValues(typeof(FoodType)))
        {
            _foodStorage.Add(foodType, 0);
        }
    }
    
    public int GetFoodAmount(FoodType foodType)
    {
        return _foodStorage[foodType];
    }

    public void AddFood(FoodType foodType, int nbAdd)
    {
        _foodStorage[foodType] += nbAdd;
        OnFoodAmountChanged?.Invoke(foodType, _foodStorage[foodType]);
    }

    public bool SpendFood(FoodType foodType, int nbSpend)
    {
        if (_foodStorage[foodType] < nbSpend)
        {
            return false;
        }
        _foodStorage[foodType] -= nbSpend;
        OnFoodAmountChanged?.Invoke(foodType, _foodStorage[foodType]);
        return true;
    }
}
