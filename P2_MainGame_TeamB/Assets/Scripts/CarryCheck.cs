using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarryCheck : MonoBehaviour
{
    private bool onload = false;
    private bool release = false;
    private string goods = " ";
    private GameObject player;

    private void Update()
    {

        if (Input.GetKeyDown("space") && onload && goods == "Player")
        {
            Debug.Log(goods);
            release = true;
            Destroy(player.GetComponent<HingeJoint2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
            && !onload)
        {
            goods = collision.gameObject.tag;
            player = collision.gameObject;
            collision.gameObject.AddComponent<HingeJoint2D>();
            collision.gameObject.GetComponent<HingeJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            onload = true;
        }    
    }

}