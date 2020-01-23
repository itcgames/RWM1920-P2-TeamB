using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    public GameObject Bomb;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "PressurePlate")
        {
            Debug.Log("Player collided with Pressure Plate");
            GameObject.Find("Bomb").GetComponent<BombScript>().SetActive(true);
        }
    }
}
