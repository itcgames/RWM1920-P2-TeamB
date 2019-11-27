using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryCheck : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "magnet")
        {
            Debug.Log("generate");
            gameObject.AddComponent<HingeJoint2D>();
            gameObject.GetComponent<HingeJoint2D>().connectedBody = collision.GetComponent<Rigidbody2D>();
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "magnet")
        {
            Debug.Log("remove");
            //Destroy(gameObject.GetComponent<HingeJoint2D>());
        }
    }

}
