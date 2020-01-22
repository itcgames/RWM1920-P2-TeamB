using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DionLevelManager : MonoBehaviour
{
    public GameObject fan;
    public GameObject ballon1;
    public GameObject ballon2;
    public GameObject platform;
    private bool isPlayerReady = false;

    // Start is called before the first frame update
    IEnumerator deleteBalloon()
    {
        yield return new WaitForSeconds(7.5f);

        ballon1.SetActive(false);
    }
    void Update()
    {
        if (ballon1.GetComponentInChildren<CarryCheck>().getOnLoad())
        {
            isPlayerReady = true;
        }
        if (isPlayerReady)
        {
            fan.GetComponentInChildren<FanArea>().enabled = true;
            fan.GetComponentInChildren<RotateFanBlade>().enabled = true;
            AudioSource[] audioSources = fan.GetComponentsInChildren<AudioSource>();
            foreach (AudioSource source in audioSources)
            {
                source.enabled = true;
            }
            var emission = fan.GetComponentInChildren<ParticleSystem>().emission;
            emission.enabled = true;

            Rigidbody2D[] rbs = ballon1.GetComponentsInChildren<Rigidbody2D>();
            foreach (Rigidbody2D rb in rbs)
            {
                rb.simulated = true;
            }
            ballon1.GetComponentInChildren<BalloonMovement>().enabled = true;

            Rigidbody2D[] rbs2 = ballon2.GetComponentsInChildren<Rigidbody2D>();
            foreach (Rigidbody2D rb in rbs2)
            {
                rb.simulated = true;
            }
            ballon2.GetComponentInChildren<BalloonMovement>().enabled = true;
            platform.GetComponent<PlatformScript>().activate = true;
            StartCoroutine(deleteBalloon());
        }
    }
}
