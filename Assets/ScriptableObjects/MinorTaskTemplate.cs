using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ResourceRange
{
    public ResourceTypeEnum resourceType;
    public int min, max;
}

[CreateAssetMenu(fileName = "NewMinorTask", menuName = "Data/Task/Minor Task")]
public class MinorTaskTemplate : AbstractTaskTemplate
{
    public List<ResourceRange> availableResources;
    public int nbResourcesToDraw;
    public int minReward, maxReward;

    public override string GetGoalFlavorText()
    {
        string customer;  
        if (Random.Range(0.0f, 1.0f) > 0.5f)
        {
            customer = $"The city {GameManager.Instance.flavorTextGenerator.GetRandomCity()}";
        }
        else
        {
            customer = $"The country {GameManager.Instance.flavorTextGenerator.GetRandomCountry()}";
        }

        string target = GameManager.Instance.flavorTextGenerator.GetRandomTarget();

        string result = $"{customer} needs your help to feed their {target}.";
        return result;
    }

    public override ResourceDict GetGoalResourceDict()
    {
        ResourceDict goalResourceDict = new ResourceDict();
        // Create a weighted list to chose randomly multiple resources
        WeightedList<ResourceRange> drawList = new WeightedList<ResourceRange>();
        availableResources.ForEach(value => drawList.Add(value, 1));
        
        for (int i = 0; i < nbResourcesToDraw; i++)
        {
            // Draw a random resource for the goal
            ResourceRange drawnElement = drawList.GetRandomElement();
            goalResourceDict.Add(drawnElement.resourceType, Random.Range(drawnElement.min, drawnElement.max+1));
            // Ignore for future draws
            drawList.SetWeightOfObject(drawnElement, 0);
        }

        return goalResourceDict;
    }
}
