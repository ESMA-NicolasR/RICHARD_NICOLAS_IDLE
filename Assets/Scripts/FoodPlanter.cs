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
    [SerializeField] private TextMeshProUGUI _actionText;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        SeedManager.OnNbSeedsChanged += OnNbSeedsChanged;
    }

    private void OnDisable()
    {
        SeedManager.OnNbSeedsChanged -= OnNbSeedsChanged;
    }

    private void Start()
    {
        UpdateDisplay(SeedManager.Instance.GetSeedNb());
    }

    public void PlantFood()
    {
        // Find an available field plot
        GameObject fieldPlot = FieldPlotManager.Instance.GetIdleFieldPlot();
        if (fieldPlot == null)
        {
            Debug.Log("No field plot available");
            return;
        }
        // Pay for the food
        if (!SeedManager.Instance.SpendSeeds(_food.GetSeedCost()))
        {
            Debug.LogError("Not enough seed");
            return;
        }
        // Plant the food
        fieldPlot.GetComponent<FieldPlot>().SetFood(_food);
    }

    private void OnNbSeedsChanged(int nbSeeds)
    {
        UpdateDisplay(nbSeeds);
    }

    private void UpdateDisplay(int nbSeeds)
    {
        _priceText.text = _food.GetIconRepresentation();
        if(nbSeeds < _food.GetSeedCost())
        {
            // _actionText.color = Color.red;
            _button.interactable = false;
        }
        else
        {
            // _actionText.color = Color.white;
            _button.interactable = true;
        }
    }
}
