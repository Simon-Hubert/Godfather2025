using UnityEngine;

public class Solution : MonoBehaviour
{
    public int diseaseId;
    
    public void SetSprite(Sprite recipeSprite) {
        GetComponent<SpriteRenderer>().sprite = recipeSprite;
    }
}
