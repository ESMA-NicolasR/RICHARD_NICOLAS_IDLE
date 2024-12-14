using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewManualCostUpgrade", menuName = "Data/Upgrade/Manual Cost")]
public class ManualCostUpgradeTemplate : UpgradeTemplate
{
    // FIXME cannot be serialized
    public List<ResourceDict> allCosts;
    public ResourceDict cost;

    public override ResourceDict GetCostForRank(int rank)
    {
        return allCosts[rank];
    }
    
    public override int GetMaxRank()
    {
        return allCosts.Count;
    }
}
