public abstract class AbstractTask
{
    public ResourceDict goalResourceDict;
    public string goalFlavorText;
    public string rewardFlavorText;
    public abstract void ClaimReward();
}
