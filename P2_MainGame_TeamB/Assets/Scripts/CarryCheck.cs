using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarryCheck : MonoBehaviour
{
    public Button releaseButton;


    private bool onload = false;
    private string goods = " ";
    private GameObject player;
    private float timer = 0.0f;

    private void Start()
    {
        releaseButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (onload && goods == "Player")
        {
            releaseButton.gameObject.SetActive(true);
        }

        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                releaseButton.gameObject.SetActive(false);
                onload = false;
            }
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

    public void ReleaseTheBall()
    {
        if (onload && goods == "Player")
        {
            Debug.Log(goods);
            timer = 0.30f;
            Destroy(player.GetComponent<HingeJoint2D>());
        }
    }

}