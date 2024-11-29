using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPlanter : MonoBehaviour
{
    [SerializeField] private GameObject _foodGrowerPrefab;
    [SerializeField] private Transform _cropsField;

    public void PlantSeed(Food food)
    {
        if (!SeedManager.Instance.SpendSeeds(food.GetSeedCost()))
        {
            Debug.LogError("Pas assez de seed");
            return;
        }
        // Vérifier qu'on a un champ disponible
        if(false)
        {
            Debug.Log("Pas de champ libre");
            return;
        }
        GameObject foodGrower = Instantiate(_foodGrowerPrefab, _cropsField);
        foodGrower.GetComponent<FoodGrower>().SetFood(food);
    }
}
