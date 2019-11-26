
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("do something");
        if (collision.tag == "balloon")
        {
            Destroy(collision.gameObject);
        }
    }
}
