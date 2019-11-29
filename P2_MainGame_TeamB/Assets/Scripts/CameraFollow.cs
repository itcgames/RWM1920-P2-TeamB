using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow: MonoBehaviour
{
    private const float ROOFBASE = 14.2f;
    private const float LEFTBASE = -4;
    private const float RIGHTBASE = 4;
    private const float FLOORBASE = -14.2f;
    
    // Dion Scene don't overwrite
    // TODO: Add constraint for these values if scene == dionScene
    // OR syncronize cameras / backgrounds
    private const float ROOF = 14.5f;
    private const float LEFT = -8.3f;
    private const float RIGHT = 11;


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
        if (SceneManager.GetActiveScene().name == "dionScene")
        {
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
            if (ball.transform.position.y < FLOORBASE)
            {
                transform.position = new Vector3(transform.transform.position.x, FLOORBASE, transform.transform.position.z + camOffsetZ);
            }
        }
        else
        {
            if (ball.transform.position.y > ROOFBASE)
            {
                transform.position = new Vector3(transform.transform.position.x, ROOF, transform.transform.position.z + camOffsetZ);
            }
            if (ball.transform.position.x < LEFTBASE)
            {
                transform.position = new Vector3(LEFT, transform.transform.position.y, transform.transform.position.z + camOffsetZ);
            }
            if (ball.transform.position.x > RIGHTBASE)
            {
                transform.position = new Vector3(RIGHT, transform.transform.position.y, transform.transform.position.z + camOffsetZ);
            }
            if (ball.transform.position.y < FLOORBASE)
            {
                transform.position = new Vector3(transform.transform.position.x, FLOORBASE, transform.transform.position.z + camOffsetZ);
            }
        }
    }
}
