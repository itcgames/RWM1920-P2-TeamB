using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceAmount = 10;
    private Vector2 velocity;

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision");
        // something like if the collision is from the top side
        if (col.gameObject.GetComponent<Transform>().position.y >= this.gameObject.GetComponent<Transform>().position.y)
        {
            Debug.Log("Above");
            bounce(col.gameObject);
        }
    }
    public void bounce(GameObject other)
    {
        velocity = other.GetComponent<Rigidbody2D>().velocity;
        velocity.y = 0;
        other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, bounceAmount));
        Debug.Log("Bounce?");
    }
}
