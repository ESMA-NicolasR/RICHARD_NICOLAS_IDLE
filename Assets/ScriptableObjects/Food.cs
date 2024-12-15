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

    public int GetSeedCost()
    {
        return baseSeedCost;
    }

    public int GetYieldAmount()
    {
        return baseYieldAmount;
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
