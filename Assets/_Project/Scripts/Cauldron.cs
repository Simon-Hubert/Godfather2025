using UnityEngine;

public class CauldronTrigger : MonoBehaviour
{
    public SOCurrentRecipe currentRecipe;

    private void OnTriggerEnter(Collider other)
    {
        IngredientObject ingredient = other.GetComponent<IngredientObject>();

        if (ingredient != null)
        {
            currentRecipe.AddIngredient(ingredient.ingredientType);

            Debug.Log("Ingredient " + ingredient.ingredientType);

            Destroy(other.gameObject);
        }
    }
}
