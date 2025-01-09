using UnityEngine;

[CreateAssetMenu(fileName = "NewAutoCostUpgrade", menuName = "Data/Upgrade/Auto Cost")]
public class AutoCostUpgradeTemplate : UpgradeTemplate
{
    public int maxRank;
    public ResourceDict baseCost;
    public float exponent;

    public override ResourceDict GetCostForRank(int rank)
    {
        ResourceDict newCost = new ResourceDict();
        // Formula is cost = baseCost * exponent ^ rank
        baseCost.ForEach((key, value) => newCost.Add(key, (long)(value*Mathf.Pow(exponent, rank))));
        
        return newCost;
    }

    public override int GetMaxRank()
    {
        return maxRank;
    }
}
