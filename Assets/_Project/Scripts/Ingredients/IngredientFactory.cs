using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class IngredientFactory : MonoBehaviour
{
    [SerializeField] private Ingredient _ingredientPrefab;
    [SerializeField] private IngredientDatabase _database;
    
    public Ingredient SpawnIngredient(Vector3 position, int id) {
        Ingredient ingredient = Instantiate(_ingredientPrefab, position, Quaternion.identity);
        ingredient.Init(_database.Data[id], 0);
        return ingredient;
    }
}