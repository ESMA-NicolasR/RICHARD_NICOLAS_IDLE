using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class FoodCounter : MonoBehaviour
{
    [FormerlySerializedAs("_foodType")] [SerializeField] private FoodTypeEnum foodTypeEnum;
    [SerializeField] private TextMeshProUGUI _foodText;

    private void OnEnable()
    {
        FoodManager.OnFoodAmountChanged += OnFoodAmountChanged;
    }

    private void OnFoodAmountChanged(FoodTypeEnum foodTypeEnum, int amount)
    {
        if (foodTypeEnum == this.foodTypeEnum)
        {
            _foodText.text = amount.ToString();
        }
    }
}
