using UnityEngine;
using System.Collections;
public class DraggableItem : MonoBehaviour
{
    [SerializeField] private Camera cam1;
    [SerializeField] private float speed;
    [SerializeField] private float f;
    private Rigidbody2D rb;
    Vector3 mousePosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam1 = Camera.main;
    }

    private Vector3 GetMousePos()
    {
        return cam1.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }
    private void OnMouseDrag()
    {
        Vector2 direction = transform.position - cam1.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        Vector2 norm = direction;

        rb.gravityScale = 0;
        rb.velocity = rb.velocity * f;
        rb.velocity += -direction * speed * Time.deltaTime;
    }
    private void OnMouseUp()
    {
        rb.gravityScale = 1;
    }
}