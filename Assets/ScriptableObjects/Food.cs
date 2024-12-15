using System.Text;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewFood", menuName = "Data/Ressources/Food")]
public class Food : ScriptableObject
{
    // Display
    public string foodName;
    public Sprite growingSprite;
    public Sprite ripeSprite;
    
    // Gameplay
    public ResourceTypeEnum resourceTypeEnum;
    public int baseSeedCost;
    public float baseTimeToGrow;
    public int baseYieldAmount;

    // Tweaking
    private const float SPEED_SCALING = 0.95f;
    private const float MIN_TIME_TO_GROW = 0.1f;
    private const float YIELD_SCALING = 1.1f;

    public int GetSeedCost()
    {
        return baseSeedCost;
    }

    public int GetYieldAmount()
    {
        // Formula is yield = baseYield [+cerealYield] * YIELD_SCALING ^ ExpGlobalYield
        int additiveYield = resourceTypeEnum == ResourceTypeEnum.Cereal ? (int)GameManager.Instance.upgradeManager.GetScalingValue(UpgradeScalingEnum.AddCerealYield) : 0;
        float multYield = Mathf.Pow(YIELD_SCALING, GameManager.Instance.upgradeManager.GetScalingValue(UpgradeScalingEnum.ExpGlobalYield));
        
        return (int)((baseYieldAmount + additiveYield) * multYield);
    }

    public float GetTimeToGrow()
    {
        // Formula is time = (baseTime [-fruitSpeed]) * SPEED_SCALING ^ ExpGlobalGrowSpeed
        // Minimum time is MIN_TIME_TO_GROW
        float additiveTime = resourceTypeEnum == ResourceTypeEnum.Fruit ? GameManager.Instance.upgradeManager.GetScalingValue(UpgradeScalingEnum.AddFruitGrowSpeed) : 0f;
        float multTime = Mathf.Pow(SPEED_SCALING, GameManager.Instance.upgradeManager.GetScalingValue(UpgradeScalingEnum.ExpGlobalGrowSpeed));
        float newTime = (baseTimeToGrow - additiveTime) * multTime;
        
        return Mathf.Max(newTime, MIN_TIME_TO_GROW);
    }

    public string GetYieldSprite()
    {
        string foodCategorySprite = "";
        switch (resourceTypeEnum)
        {
            case ResourceTypeEnum.Cereal:
                foodCategorySprite = "cereal";
                break;
            case ResourceTypeEnum.Fruit:
                foodCategorySprite = "fruit";
                break;
            case ResourceTypeEnum.Vegetable:
                foodCategorySprite = "vegetable";
                break;
            default:
                Debug.Log("Unknown Food Type");
                break;
        }
        return $"<sprite name={foodCategorySprite}>";
    }
}
