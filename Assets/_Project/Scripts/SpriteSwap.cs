using UnityEngine;

public class SpriteSwap : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;

    public float swapInterval = 1f;

    private SpriteRenderer spriteRenderer;
    private bool isUsingSprite1 = true;
    private float timer = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            enabled = false;
            return;
        }

        spriteRenderer.sprite = sprite1;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= swapInterval)
        {
            SwapSprite();
            timer = 0f;
        }
    }

    void SwapSprite()
    {
        if (isUsingSprite1)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }

        isUsingSprite1 = !isUsingSprite1;
    }
}
