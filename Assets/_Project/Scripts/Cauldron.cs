using UnityEngine;
using System.Collections;
public class Cauldron : MonoBehaviour
{
    private bool isCooking = false;
    private float cookTimer;
    public SOCurrentRecipe currentRecipe;
    private bool isInside = false;
    private Collider inside = null;
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
    }
    private void checkRecipe(float cookTimer)
    {
        Debug.Log("Cooked for " + cookTimer + " seconds.");
    }
    private void OnTriggerEnter(Collider other)
    {
        
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
