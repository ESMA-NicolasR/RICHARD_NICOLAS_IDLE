using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodCounter : MonoBehaviour
{
    [SerializeField] private FoodType _foodType;
    [SerializeField] private TextMeshProUGUI _foodText;

    private void OnEnable()
    {
        FoodManager.OnFoodAmountChanged += OnFoodAmountChanged;
    }

    private void OnFoodAmountChanged(FoodType foodType, int amount)
    {
        if (foodType == _foodType)
        {
            _foodText.text = amount.ToString();
        }
    }
}
