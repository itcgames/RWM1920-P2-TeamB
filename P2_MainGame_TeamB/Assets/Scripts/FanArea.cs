﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanArea : MonoBehaviour
{
    public float strength;
    public Vector3 direction;
    public Vector3 size;

    private GameObject AirFlow;
    protected Rigidbody2D rb;

    public AudioSource m_MyAudioSource;
    private float m_MySliderValue;

    private List<Rigidbody2D> m_affectedObjects;

    private void Start()
    {
             m_MySliderValue = strength/100;
            m_MyAudioSource = GetComponent<AudioSource>();
            m_MyAudioSource.volume = m_MySliderValue;
            m_MyAudioSource.Play();


        m_affectedObjects = new List<Rigidbody2D>();
        ParticleSystem.MainModule ps = gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().main;
        ps.startSpeed = strength * size.x;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.localScale = new Vector3(size.x * strength, size.y, size.z);

        foreach (var item in m_affectedObjects)
        {
            moveObject(item, direction, strength);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<Rigidbody2D>() == true)
        {
            rb = coll.gameObject.GetComponent<Rigidbody2D>();
            m_affectedObjects.Add(rb);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        for (int i = m_affectedObjects.Count - 1; i >= 0; i--)
        {
            if (coll.gameObject == m_affectedObjects[i].gameObject)
            {
                m_affectedObjects.RemoveAt(i);
            }
        }
    }


    public static void moveObject(Rigidbody2D t_rb, Vector3 t_direction, float t_strength)
    {
        t_rb.AddForce(t_direction * t_strength);
    }

}

