using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.VFX;
public class Cauldron : MonoBehaviour
{
    private bool isCooking = false;
    private float cookTimer;
    public SOCurrentRecipe currentRecipe;
    [SerializeField] private RecipeManager _recipeManager;
    [SerializeField] private Transform _potionSpawn;

    [Header("FX & Sprite")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Color> spriteColors;
    [SerializeField, GradientUsage(true)] private List<Gradient> gradientsBubble;
    [SerializeField] private VisualEffect vfx;

    [SerializeField] private Animator animator;

    private bool isInside = false;
    private Collider2D inside = null;
    
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
        if (Input.GetMouseButtonUp(0) && isInside)
        {
            Debug.Log("Cauldron Clicked");
            Ingredient ingredient = inside.GetComponent<Ingredient>();

            if (ingredient != null)
            {
                currentRecipe.AddIngredient(ingredient.Id);
                AudioManager.Instance?.PlaySFX(0);
    
                Debug.Log("Ingredient " + ingredient.Id);

                Destroy(inside.gameObject);
            }
        }
    }
    private void OnMouseDown()
    {
        AudioManager.Instance?.PlaySFX(5);
    }
    private void OnMouseDrag()
    {
        isCooking = true;
        animator.SetBool("isCooking", true);
    }
    private void OnMouseUp()
    {
        isCooking = false;
        animator.SetBool("isCooking", false);

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
                AudioManager.Instance?.PlaySFX(4);
                Solution solution = Instantiate(recipe.solution, _potionSpawn.position, Quaternion.identity).GetComponent<Solution>();
                solution.SetSprite(recipe.Sprite);
                if (recipe.Id == 14) {
                    solution.OnFantaDeFrancko();
                }
                return;
            }
        }
        Debug.Log("Cooked during " + cookTimer);
        
        //this.currentRecipe.ResetRecipe();
    }

    private bool AreRecipesEqual(List<int> current, List<int> target)
    {
        if (current.Count != target.Count) return false;
        return !target.Except(current).Any() && !current.Except(target).Any();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        inside = other;
        isInside = true;

        if (spriteRenderer != null && spriteColors.Count > 0 && gradientsBubble.Count > 0)
        {
            int index = Random.Range(0, Mathf.Min(spriteColors.Count, gradientsBubble.Count));
            spriteRenderer.color = spriteColors[index];
            if (vfx != null)
            {
                vfx.SetGradient("MainColorGradient", gradientsBubble[index]);
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        inside = null;
        isInside = false;
    }
}
