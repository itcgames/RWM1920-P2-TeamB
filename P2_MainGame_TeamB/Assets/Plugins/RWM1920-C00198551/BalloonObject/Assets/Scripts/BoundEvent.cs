using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundEvent : MonoBehaviour {

    private Vector2 balloonPosition;

    void Start()
    {
        //balloonPosition = gameObject.GetComponent<BalloonMovement>().balloonPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("balloon")) // check the collision between player and pickups
        {
            balloonPosition.y = balloonPosition.y + collision.gameObject.transform.position.y;
            transform.position = balloonPosition;
            Debug.Log("OntriggerEnter");
        }
    }

}
