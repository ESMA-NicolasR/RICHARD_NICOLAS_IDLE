using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewManualCostUpgrade", menuName = "Data/Upgrade/Manual Cost")]
public class ManualCostUpgradeTemplate : UpgradeTemplate
{
    public List<ResourceDict> allCosts;

    public override ResourceDict GetCostForRank(int rank)
    {
        return allCosts[rank];
    }
    
    public override int GetMaxRank()
    {
        return allCosts.Count;
    }
}
