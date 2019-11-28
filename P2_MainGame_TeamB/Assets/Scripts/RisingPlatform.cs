using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    public float speed;
    public bool activate;
    private Rigidbody2D rb2d;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (activate)
        {
            movement = new Vector2(0, speed);
            rb2d.velocity = movement;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.gameObject.tag == "Player")
        {
            activate = true;
        }
    }
}
