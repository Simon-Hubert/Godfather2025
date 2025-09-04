using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
public class Cauldron : MonoBehaviour
{
    private bool isCooking = false;
    private float cookTimer;
    public SOCurrentRecipe currentRecipe;
    [SerializeField] private RecipeManager _recipeManager;

    private bool isInside = false;
    private Collider inside = null;
    void Update()
    {
        if (isCooking)
        {
            cookTimer += Time.deltaTime;
        }
        currentRecipe.timer = cookTimer;
        /*        else
                {
                    if (cookTimer > 0f)
                    {
                        CheckRecipe(cookTimer, currentRecipe, );
                    }
                    //cookTimer = 0f;

                }*/
        //Debug.Log("Cooked during " + cookTimer);
        if (Input.GetMouseButtonUp(0))
        {
            IngredientObject ingredient = inside.GetComponent<IngredientObject>();

            if (ingredient != null)
            {
                currentRecipe.AddIngredient(ingredient.ingredientType);

                Debug.Log("Ingredient " + ingredient.ingredientType);

                Destroy(inside.gameObject);
            }
        }
    }
    private void OnMouseDrag()
    {
        isCooking = true;
    }
    private void OnMouseUp()
    {
        isCooking = false;

        if (cookTimer > 0f)
        {
            CheckRecipe(cookTimer, currentRecipe, _recipeManager.allRecipes);
            cookTimer = 0f;
        }
    }
    private void CheckRecipe(float cookTime, SOCurrentRecipe currentRecipe, List<SORecipe> recipeList)
    {
        recipeList = _recipeManager.allRecipes;
        foreach (SORecipe recipe in recipeList)
        {
            if (AreRecipesEqual(currentRecipe.currentIngredients, recipe.ingredients) && Mathf.Abs(cookTime - recipe.timer) <= 1f)
            {
                //Debug.Log($"Recette r�ussie : {recipe.recipeName} avec {cookTime:F1}s de cuisson !");
                Debug.Log("win");
                Instantiate(recipe.solution);
                return;
            }
            Debug.Log("Cooked during " + cookTimer);
        }
    }

    private bool AreRecipesEqual(List<IngredientType> current, List<IngredientType> target)
    {
        if (current.Count != target.Count) return false;
        return !target.Except(current).Any() && !current.Except(target).Any();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        
    }
    void OnTriggerEnter(Collider other)
    {
        inside = other;
        isInside = true;
    }
    void OnTriggerExit(Collider other)
    {
        inside = null;
        isInside = false;
    }
}
