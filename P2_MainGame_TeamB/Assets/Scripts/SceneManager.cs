using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public GameObject m_balloon;
    public GameObject m_bomb;
    public GameObject m_tb;
    public GameObject m_pp;
    public GameObject m_tramp;
    public GameObject m_fan;
    public Button m_ballonBtn;
    public Button m_bombBtn;
    public Button m_tbBtn;
    public Button m_ppBtn;
    public Button m_trampBtn;
    public Button m_fanBtn;


    private bool m_isHeldDown;
    private float m_startPosX;
    private float m_startPosY;
    Vector3 m_mousePos;
    void OnEnable()
    {
        //Register Button Events
        m_ballonBtn.onClick.AddListener(() => buttonCallBack(m_ballonBtn));
        m_bombBtn.onClick.AddListener(() => buttonCallBack(m_bombBtn));
        m_tbBtn.onClick.AddListener(() => buttonCallBack(m_tbBtn));
        m_ppBtn.onClick.AddListener(() => buttonCallBack(m_ppBtn));
        m_trampBtn.onClick.AddListener(() => buttonCallBack(m_trampBtn));
        m_fanBtn.onClick.AddListener(() => buttonCallBack(m_fanBtn));
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left button.");
            m_mousePos = Input.mousePosition;
            m_mousePos = Camera.main.ScreenToWorldPoint(m_mousePos);

            m_startPosX = m_mousePos.x - transform.localPosition.x;
            m_startPosY = m_mousePos.y - transform.localPosition.y;

            m_isHeldDown = true;
        }
    }

    void OnMouseUp()
    {
        m_isHeldDown = false;
    }
    public bool getObjectHeldDown()
    {
        return m_isHeldDown;
    }
    public void SetHeldDown(bool t_heldDown)
    {
        m_isHeldDown = t_heldDown;
    }
    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == m_ballonBtn)
        {
            Debug.Log("Clicked: " + m_ballonBtn.name);
            Instantiate(m_balloon);
        }

        if (buttonPressed == m_bombBtn)
        {
            Debug.Log("Clicked: " + m_bombBtn.name);
            Instantiate(m_bomb);
 
        }

        if (buttonPressed == m_tbBtn)
        {
            Debug.Log("Clicked: " + m_tbBtn.name);
            Instantiate(m_tb);

        }


        if (buttonPressed == m_ppBtn)
        {
            Debug.Log("Clicked: " + m_ppBtn.name);
            Instantiate(m_pp);

        }
        if (buttonPressed == m_trampBtn)
        {
            Debug.Log("Clicked: " + m_trampBtn.name);
            Instantiate(m_tramp);

        }
        if (buttonPressed == m_fanBtn)
        {
            Debug.Log("Clicked: " + m_fanBtn.name);
            Instantiate(m_fan);

        }
    }
}
