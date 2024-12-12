using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTask
{
    public ResourceDict goalResourceDict;
    public string goalFlavorText;
    public string rewardFlavorText;
    public abstract void ClaimReward();
}

public class MinorTask : AbstractTask
{
    private double _reward;

    public MinorTask(MinorTaskTemplate template)
    {
        goalResourceDict = template.GetGoalResourceDict();
        goalFlavorText = template.GetGoalFlavorText();
        _reward = Random.Range(template.minReward, template.maxReward);
        //TODO replace with world hunger
        rewardFlavorText = $"Feed <sprite name=seed>{_reward} people";
    }
    
    public override void ClaimReward()
    {
        GameManager.Instance.worldHungerManager.FeedPeople(_reward);
    }
}

public class MajorTask : AbstractTask
{
    private UpgradeEnum _upgradeReward;
    
    public MajorTask(MajorTaskTemplate template)
    {
        goalResourceDict = template.GetGoalResourceDict();
        goalFlavorText = template.GetGoalFlavorText();
        rewardFlavorText = template.rewardFlavorText;
        _upgradeReward = template.upgradeReward;
    }
    
    public override void ClaimReward()
    {
        GameManager.Instance.upgradeManager.UnlockUpgrade(_upgradeReward);
    }
}