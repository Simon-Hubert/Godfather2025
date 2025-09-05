using UnityEngine;

public class Solution : MonoBehaviour
{
    public int diseaseId;
    public bool isFantaDeFrancko;
    
    public void SetSprite(Sprite recipeSprite) {
        GetComponent<SpriteRenderer>().sprite = recipeSprite;
    }

    public void OnFantaDeFrancko() {
        isFantaDeFrancko = true;
    }
}
