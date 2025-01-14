using UnityEngine;

[CreateAssetMenu(fileName = "NewMajorTask", menuName = "Data/Task/Major Task")]
public class MajorTaskTemplate : AbstractTaskTemplate
{
    public string goalFlavorText;
    public string rewardFlavorText;
    public ResourceDict goalResourceDict;
    public UpgradeEnum upgradeReward;

    public override string GetGoalFlavorText()
    {
        return goalFlavorText;
    }

    public override ResourceDict GetGoalResourceDict()
    {
        return goalResourceDict;
    }
}