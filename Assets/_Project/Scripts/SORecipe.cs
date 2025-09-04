using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SORecipes", menuName = "Recipe/Create New Recipe")]
public class SORecipe : ScriptableObject
{
    public int Id;
    public string recipeName;
    public List<IngredientType> ingredients = new List<IngredientType>();
}
