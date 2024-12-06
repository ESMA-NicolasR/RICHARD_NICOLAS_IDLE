using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class FoodCounter : MonoBehaviour
{
    [SerializeField] private FoodTypeEnum _foodTypeEnum;
    [SerializeField] private TextMeshProUGUI _foodText;

    private void OnEnable()
    {
        FoodManager.OnFoodAmountChanged += OnFoodAmountChanged;
    }

    private void OnFoodAmountChanged(FoodTypeEnum foodTypeEnumChanged, int amount)
    {
        if (foodTypeEnumChanged == _foodTypeEnum)
        {
            _foodText.text = amount.ToString();
        }
    }
}
