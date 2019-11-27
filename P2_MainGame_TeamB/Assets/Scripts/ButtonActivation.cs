using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    public GameObject toBeActivated;

    private void Start()
    {
        toBeActivated.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D t_other)
    {
        if (t_other.CompareTag("ball"))
        {
            gameObject.SetActive(true);
        }
    }

}
