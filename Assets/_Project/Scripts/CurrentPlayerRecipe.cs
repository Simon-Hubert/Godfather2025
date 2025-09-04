using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SORecipes", menuName = "Recipe/Player Recipe")]
public class SOCurrentRecipe : ScriptableObject
{
    public float timer;
    public List<int> currentIngredients = new List<int>();

    public void AddIngredient(int ingredientId)
    {
        currentIngredients.Add(ingredientId);
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
