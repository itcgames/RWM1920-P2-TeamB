using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour
{

    public GameObject ball;
    private Vector3 camOffset;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.transform.position + camOffset;
    }
}
