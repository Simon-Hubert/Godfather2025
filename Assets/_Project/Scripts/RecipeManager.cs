using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RecipeManager : MonoBehaviour
{
    public SOCurrentRecipe currentRecipe;
    public List<SORecipe> allRecipes;

    public void ValidateRecipe()
    {
        foreach (SORecipe recipe in allRecipes)
        {
            if (AreRecipesEqual(currentRecipe.currentIngredients, recipe.ingredients))
            {
                Debug.Log("bien ouej" + recipe.recipeName);
                return;
            }
        }

        Debug.Log("pas dans les recette");
    }

    private bool AreRecipesEqual(List<int> current, List<int> target)
    {
        if (current.Count != target.Count) return false;

        return !target.Except(current).Any() && !current.Except(target).Any();
    }
}
public class Recipe
{
    public IngredientType Ingredient1;
    public IngredientType ingredient2;
    public IngredientType ingredient3;
}

public enum IngredientType
{
    Objet1,
    Objet2,
    Objet3,
    Objet4
}