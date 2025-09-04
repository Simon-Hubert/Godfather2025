using UnityEngine;
using System.Collections;
public class DraggableItem : MonoBehaviour
{
    [SerializeField] private Camera cam1;
    [SerializeField] private float speed;
    [SerializeField] private float f;
    private Rigidbody rb;
    Vector3 mousePosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        Vector3 direction = transform.position - cam1.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        Vector3 norm = direction;

        rb.useGravity = false;
        rb.velocity = rb.velocity * f;
        rb.velocity += -direction * speed * Time.deltaTime;
    }
    private void OnMouseUp()
    {
        rb.useGravity = true;
    }
}