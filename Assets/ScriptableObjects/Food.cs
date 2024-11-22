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
    public float baseSeedCost;
    public float baseTimeToGrow;
    public int baseYieldAmount;
}
