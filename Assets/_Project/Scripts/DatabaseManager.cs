using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    [SerializeField] private IngredientDatabase _ingredientDatabase;
    public static DatabaseManager instance;

    public IngredientDatabase IngredientDatabase => _ingredientDatabase;

    private void Awake() {
        if (instance) {
            Debug.LogWarning("Plusieurs instance de DatabaseManager, instance détruite");
            Destroy(this);
        }

        instance = this;
    }
}
