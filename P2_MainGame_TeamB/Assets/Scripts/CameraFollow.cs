using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow: MonoBehaviour
{

    public float ROOF;
    public float LEFT;
    public float RIGHT;
    public float FLOOR = -14.2f;

    private const float ROOFBASE = 14.2f;
    private const float LEFTBASE = -4;
    private const float RIGHTBASE = 4;
    private const float FLOORBASE = -14.2f;
    
    // Dion Scene don't overwrite
    // TODO: Add constraint for these values if scene == dionScene
    // OR syncronize cameras / backgrounds
    //private const float ROOF = 14.5f;
    //private const float LEFT = -8.3f;
    //private const float RIGHT = 11;



    public GameObject ball;
    public GameObject goal;

    private bool start;
    private Vector3 distance;
    private float timePerFrame;
    private float counter;
    public float timeForPreview;

    private float camOffsetZ;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        timePerFrame = Time.deltaTime;
        counter = 0;

        camOffsetZ  = transform.position.z - ball.transform.position.z;
        transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z + camOffsetZ);
        distance = ball.transform.position - goal.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            Time.timeScale = 0.0f;

            counter += timePerFrame;
            Debug.Log(counter);
            Debug.Log(timePerFrame);

            if (counter >= timeForPreview)
            {
                start = true;
            }
            
            if (counter < timeForPreview / 2)
            {
                transform.position = transform.position - (distance * counter / (timeForPreview / 2));
            }
            else
            {
                transform.position = transform.position + (distance * (counter - (timeForPreview / 2)) / timeForPreview);
            }

        }
        else
        {
            Time.timeScale = 1.0f;

            transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z + camOffsetZ);
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
        }
    }
}
