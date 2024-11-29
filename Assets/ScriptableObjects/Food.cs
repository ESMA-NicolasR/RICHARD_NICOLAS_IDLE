using UnityEngine;

[CreateAssetMenu(fileName = "NewFood", menuName = "Data/Ressources/Food")]
public class Food : ScriptableObject
{
    // Display
    public string foodName;
    public Sprite growingSprite;
    public Sprite ripeSprite;
    
    // Gameplay
    public FoodType foodType;
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
}
