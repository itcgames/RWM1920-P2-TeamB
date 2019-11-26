using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour {

    private Vector2 mousePosition;

    private Rigidbody2D rb;

    private float deltaX, deltaY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        if (gameObject.tag == "wire")
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
    }

    private void OnMouseUp()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
    }

}
