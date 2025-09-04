using UnityEngine;
using System.Collections;
public class Cauldron : MonoBehaviour
{
    private bool isCooking = false;
    private float cookTimer;
    public SOCurrentRecipe currentRecipe;
    void Update()
    {
        if (isCooking)
        {
            cookTimer += Time.deltaTime;
        }
        else
        {
            if (cookTimer > 0f)
            {
                checkRecipe(cookTimer);
            }
            cookTimer = 0f;
        }
    }
    private void OnMouseDrag()
    {
        isCooking = true;
    }
    private void OnMouseUp()
    {
        isCooking = false;
    }
    private void checkRecipe(float cookTimer)
    {
        Debug.Log("Cooked for " + cookTimer + " seconds.");
    }
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
