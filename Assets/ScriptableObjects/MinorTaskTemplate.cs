using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMinorTask", menuName = "Data/Task/Minor Task")]
public class MinorTaskTemplate : TaskTemplate
{
    public List<ResourceTypeEnum> availableResources;
    public int nbResourcesToDraw;
    public int minResourceGoal, maxResourceGoal;
    public int minReward, maxReward;

    public override string GetGoalFlavorText()
    {
        return "Random string";
    }

    public override ResourceDict GetGoalResourceDict()
    {
        ResourceDict goalResourceDict = new ResourceDict();
        WeightedList<ResourceTypeEnum> drawList = new WeightedList<ResourceTypeEnum>();
        availableResources.ForEach(value => drawList.Add(value, 1));
        
        for (int i = 0; i < nbResourcesToDraw; i++)
        {
            // Draw a random resource for the goal
            ResourceTypeEnum drawnElement = drawList.GetRandomElement();
            goalResourceDict.Add(drawnElement, Random.Range(minResourceGoal, maxResourceGoal));
            // Ignore for future draws
            drawList.SetWeightOfObject(drawnElement, 0);
        }

        return goalResourceDict;
    }
}
