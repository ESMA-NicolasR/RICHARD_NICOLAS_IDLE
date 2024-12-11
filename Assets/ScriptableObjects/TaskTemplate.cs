using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskTemplate : ScriptableObject
{
    public abstract string GetGoalFlavorText();
    public abstract ResourceDict GetGoalResourceDict();
}
