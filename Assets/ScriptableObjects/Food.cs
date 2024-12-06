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

    public string GetYieldIconRepresentation()
    {
        string foodCategorySprite = "";
        switch (foodTypeEnum)
        {
            case FoodTypeEnum.Cereal:
                foodCategorySprite = "cereal";
                break;
            case FoodTypeEnum.Fruit:
                foodCategorySprite = "fruit";
                break;
            case FoodTypeEnum.Vegetable:
                foodCategorySprite = "vegetable";
                break;
            default:
                Debug.Log("Unknown Food Type");
                break;
        }
        return $"<sprite name={foodCategorySprite}>{GetYieldAmount()}";
    }
}
