using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    bool m_exploded = false;
    public float m_delay = 1.0f;
    public float m_explosion_rate = 1.0f;
    public float m_maxSize = 15.0f;
    public float m_explosionSpeed = 10.0f;
    public float m_currentRadius = 0.0f;
    public bool m_activate = false;
    AudioSource m_explosionSound;
    public ParticleSystem m_particle;
    CircleCollider2D m_explosion_radius;

    private void Start()
    {
        m_explosion_radius = GetComponent<CircleCollider2D>();
        m_explosionSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(m_activate==true)
        {
            m_delay -= Time.deltaTime;
            if (m_delay <= 0)
            {
                m_exploded = true;

            }
        }

    }

    private void FixedUpdate()
    {
        if(m_exploded==true)
        {
            if(m_currentRadius < m_maxSize)
            {
                m_currentRadius += m_explosion_rate;

            }
            else
            {

                Object.Destroy(this.gameObject.transform.parent.gameObject);
            }

            m_explosion_radius.radius = m_currentRadius;
        }
       
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(m_exploded==true)
        {
            if(col.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                Vector2 targetPos = col.gameObject.transform.position;
                Vector2 bombPos = gameObject.transform.position;
                Vector2 blastDir = m_explosionSpeed * (targetPos - bombPos);
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(blastDir);
                Debug.Log("Hey2");
                m_particle.Play();
                m_explosionSound.Play();
            }

        }
    }
    public bool GetActivate()
    {
        return m_activate;
    }
    public void SetActive(bool t_activate)
    {
        m_activate = t_activate;
    }
    public bool GetExploded()
    {
        return m_exploded;
    }
    public void SetExploded(bool t_exploded)
    {
        m_activate = t_exploded;
    }
}
