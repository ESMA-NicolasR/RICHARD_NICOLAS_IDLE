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