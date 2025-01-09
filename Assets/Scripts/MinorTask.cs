using UnityEngine;

public class MinorTask : AbstractTask
{
    // Gameplay
    private long _reward;

    public MinorTask(MinorTaskTemplate template)
    {
        goalResourceDict = template.GetGoalResourceDict();
        goalFlavorText = template.GetGoalFlavorText();
        _reward = Random.Range(template.minReward, template.maxReward+1);
        rewardFlavorText = $"Feed <sprite name=hunger>{_reward} people";
    }
    
    public override void ClaimReward()
    {
        GameManager.Instance.worldHungerManager.FeedPeople(_reward);
    }
}