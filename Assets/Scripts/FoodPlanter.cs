using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodPlanter : MonoBehaviour
{
    [SerializeField] private Food _food;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _yieldText;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
    }

    private void OnDisable()
    {
        ResourceManager.OnResourceAmountChanged -= OnResourceAmountChanged;
    }

    private void Start()
    {
        UpdateDisplay(GameManager.Instance.resourceManager.GetResourceAmount(ResourceTypeEnum.Seed));
    }

    public void PlantFood()
    {
        // Find an available field plot
        GameObject fieldPlot = GameManager.Instance.fieldPlotManager.GetIdleFieldPlot();
        if (fieldPlot == null)
        {
            Debug.Log("No field plot available");
            return;
        }
        // Pay for the food
        if (!GameManager.Instance.resourceManager.SpendResource(ResourceTypeEnum.Seed, _food.GetSeedCost()))
        {
            Debug.LogError("Not enough seed");
            return;
        }
        // Plant the food
        fieldPlot.GetComponent<FieldPlot>().SetFood(_food);
    }

    private void OnResourceAmountChanged(ResourceTypeEnum resourceType, int nbResource)
    {
        if(resourceType == ResourceTypeEnum.Seed)
            UpdateDisplay(nbResource);
    }

    private void UpdateDisplay(int nbSeeds)
    {
        _priceText.text = $"<sprite name=seed>{_food.GetSeedCost()}";
        _timeText.text = $"<sprite name=timer>\n{_food.baseTimeToGrow}";
        _yieldText.text = _food.GetYieldIconRepresentation();
        _button.interactable = nbSeeds >= _food.GetSeedCost();
    }
}
