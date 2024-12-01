using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlanter : MonoBehaviour
{
    [SerializeField] private Food _food;

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
}
