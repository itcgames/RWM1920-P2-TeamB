using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    public bool activate = false;
    public float range;
    public float speed;
    public float slowDownRate = 0.3f;

    private Rigidbody2D rb2d;
    private float slowDown;
    private float m_range;

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

        m_range = range;
        if (m_range < 0)
            m_range *= -1;
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

            if (targetPositon.x - transform.position.x < m_range * slowDownRate)
            {
                slowDown = (targetPositon.x - transform.position.x) / (m_range * slowDownRate);
            }

            if (transform.position.x - startPosition.x < m_range * slowDownRate)
            {
                slowDown = (transform.position.x - startPosition.x) / (m_range * slowDownRate);
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

            if (transform.position.x - targetPositon.x < m_range * slowDownRate)
            {
                slowDown = (transform.position.x - targetPositon.x) / (m_range * slowDownRate);
            }

            if (startPosition.x - transform.position.x < m_range * slowDownRate)
            {
                slowDown = (startPosition.x - transform.position.x) / (m_range * slowDownRate);
            }
        }

        if (slowDown <= 0.15f)
        {
            slowDown = 0.15f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 tempVelocity = collision.rigidbody.velocity;
        tempVelocity.x = movement.x * 1.5f;
        collision.rigidbody.velocity = tempVelocity;
    }

    public void SetActive(bool t_activate)
    {
        activate = t_activate;
    }
}
