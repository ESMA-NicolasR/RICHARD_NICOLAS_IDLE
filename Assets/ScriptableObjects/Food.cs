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
    [FormerlySerializedAs("foodType")] public FoodTypeEnum foodTypeEnum;
    public int baseSeedCost;
    public float baseTimeToGrow;
    public int baseYieldAmount;

    public int GetSeedCost()
    {
        return baseSeedCost;
    }

    public int GetYieldAmount()
    {
        return baseYieldAmount;
    }

    public string GetIconRepresentation()
    {
        IconsEnum foodCategoryIcon = 0;
        switch (foodTypeEnum)
        {
            case FoodTypeEnum.Cereal:
                foodCategoryIcon = IconsEnum.Cereal;
                break;
            case FoodTypeEnum.Fruit:
                foodCategoryIcon = IconsEnum.Fruit;
                break;
            case FoodTypeEnum.Vegetable:
                foodCategoryIcon = IconsEnum.Vegetable;
                break;
            default:
                Debug.Log("Unknown Food Type");
                break;
        }
        return $"<sprite={(int)IconsEnum.Seed}>x{GetSeedCost()}" +
               $"<sprite={(int)IconsEnum.Timer}>{baseTimeToGrow}s" +
               $"<sprite={(int)foodCategoryIcon}>x{GetYieldAmount()}";
    }
}
