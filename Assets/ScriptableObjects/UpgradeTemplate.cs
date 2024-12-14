using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeTemplate : ScriptableObject
{
    public UpgradeEnum upgrade;
    public string description;
    public abstract ResourceDict GetCostForRank(int rank);
    public abstract int GetMaxRank();
}
