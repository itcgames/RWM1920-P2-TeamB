
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObject : MonoBehaviour
{
    private SceneManager manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log("do something");
        if (collision.tag == "balloon")
        {
            Destroy(collision.gameObject);
        }
        
    }
}
