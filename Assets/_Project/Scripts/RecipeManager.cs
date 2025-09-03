using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Recipe
{
    public IngredientType Ingredient1;
    public IngredientType ingredient2;
    public IngredientType ingredient3;
    public IngredientType nullIngredient;
}

public enum IngredientType
{
    Objet1,
    Objet2,
    Objet3,
    Null
}