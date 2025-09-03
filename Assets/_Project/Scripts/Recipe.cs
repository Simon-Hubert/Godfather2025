using UnityEngine;

[CreateAssetMenu(fileName = "SORecipes", menuName = "Recipe/Create New Recipe")]
public class SORecipe : ScriptableObject
{
    public int Id;
    public Recipe Recipe;
}
