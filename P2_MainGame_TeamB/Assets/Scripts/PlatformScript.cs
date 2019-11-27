﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    public bool activate = false;
    public float range = 20f;
    public float speed = 10;
    public float slowDownRate = 0.3f;

    private Rigidbody2D rb2d;
    private float slowDown;

    Vector2 startPosition;
    Vector2 targetPositon;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        startPosition = transform.position;
        targetPositon = startPosition;
        targetPositon.x += range;
        slowDown = 0;
    }

    private void FixedUpdate()
    {

        if (activate)
        {
            movement = new Vector2(speed * slowDown, 0);
        }
        else
        {
            movement = new Vector2(0, 0);
        }

        rb2d.velocity = movement;
        changeDirection();
    }

    private void changeDirection()
    {
        slowDown = 1;

        if (speed > 0)
        {
            if (transform.position.x >= targetPositon.x)
            {
                Vector2 tempPosition = startPosition;
                startPosition = targetPositon;
                targetPositon = tempPosition;

                speed *= -1;
            }

            if (targetPositon.x - transform.position.x < range * slowDownRate)
            {
                slowDown = (targetPositon.x - transform.position.x) / (range * slowDownRate);
            }

            if (transform.position.x - startPosition.x < range * slowDownRate)
            {
                slowDown = (transform.position.x - startPosition.x) / (range * slowDownRate);
            }
        }
        else if (speed < 0)
        {
            if (transform.position.x <= targetPositon.x)
            {
                Vector2 tempPosition = startPosition;
                startPosition = targetPositon;
                targetPositon = tempPosition;

                speed *= -1;
            }

            if (transform.position.x - targetPositon.x < range * slowDownRate)
            {
                slowDown = (transform.position.x - targetPositon.x) / (range * slowDownRate);
            }

            if (startPosition.x - transform.position.x < range * slowDownRate)
            {
                slowDown = (startPosition.x - transform.position.x) / (range * slowDownRate);
            }
        }

        if (slowDown <= 0.15f)
        {
            slowDown = 0.15f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.rigidbody.velocity = movement;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    public void SetActive(bool t_activate)
    {
        activate = t_activate;
    }
}
