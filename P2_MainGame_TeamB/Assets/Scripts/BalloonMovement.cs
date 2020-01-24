using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour {

    public float force;
    public Vector2 balloonPosition;

    private Rigidbody2D rb2d;
    private float moveVertical = 0;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    public static float getVelocity(float force, float mass)
    {
        float acceleration = (force - mass) / mass; // force = mass * acceleration

        float velocity = acceleration * Time.deltaTime; // velocity = acceleration * time
        
        return velocity;
    }

    void FixedUpdate()
    {
        moveVertical = getVelocity(force, rb2d.mass);

        Debug.Log(moveVertical);
        Vector2 movement = new Vector2(0, moveVertical);

        rb2d.AddForce(movement);

        balloonPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
