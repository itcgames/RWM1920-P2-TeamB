using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlatform : MonoBehaviour
{

    public PlatformScript platform;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Wall")
        {
            Debug.Log(other.gameObject.name);
            platform.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        platform.SetActive(false);
    }
}
