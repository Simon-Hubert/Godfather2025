using UnityEngine;

[CreateAssetMenu(fileName = "SORecipes", menuName = "Recipe/Player Recipe")]
public class SOCurrentRecipe : ScriptableObject
{
    public IngredientType ingredient1;
    public IngredientType ingredient2;
    public IngredientType ingredient3;
    public IngredientType ingredient4;
}
