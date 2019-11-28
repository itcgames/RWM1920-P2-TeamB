using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour
{
    private const float ROOF = 14.2f;
    private const float LEFT = -4;
    private const float RIGHT = 4;
    private const float FLOOR = -14.2f;


    public GameObject ball;
    private float camOffsetZ;

    // Start is called before the first frame update
    void Start()
    {
        camOffsetZ  = transform.position.z - ball.transform.position.z;
        transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z + camOffsetZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z + camOffsetZ);
        if (ball.transform.position.y > ROOF)
        {
            transform.position = new Vector3(transform.transform.position.x, ROOF, transform.transform.position.z + camOffsetZ);
        }
        if (ball.transform.position.x < LEFT)
        {
            transform.position = new Vector3(LEFT, transform.transform.position.y, transform.transform.position.z + camOffsetZ);
        }
        if (ball.transform.position.x > RIGHT)
        {
            transform.position = new Vector3(RIGHT, transform.transform.position.y, transform.transform.position.z + camOffsetZ);
        }
        if (ball.transform.position.y < FLOOR)
        {
            transform.position = new Vector3(transform.transform.position.x, FLOOR, transform.transform.position.z + camOffsetZ);
        }
    }
}
