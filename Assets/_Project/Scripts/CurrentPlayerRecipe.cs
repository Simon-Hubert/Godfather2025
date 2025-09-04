using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SORecipes", menuName = "Recipe/Player Recipe")]
public class SOCurrentRecipe : ScriptableObject
{
    public float timer;
    public List<IngredientType> currentIngredients = new List<IngredientType>();

    public void AddIngredient(IngredientType ingredient)
    {
        currentIngredients.Add(ingredient);
    }

    public void ResetRecipe()
    {
        currentIngredients.Clear();
    }
    private void OnEnable()
    {
        currentIngredients.Clear();
    }
}
