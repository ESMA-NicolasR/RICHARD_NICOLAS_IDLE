using UnityEngine;

public abstract class AbstractTaskTemplate : ScriptableObject
{
    public abstract string GetGoalFlavorText();
    public abstract ResourceDict GetGoalResourceDict();
}
