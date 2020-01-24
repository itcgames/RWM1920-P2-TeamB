using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerr : MonoBehaviour
{
    public GameObject m_balloon;
    public GameObject m_bomb;
    public GameObject m_tb;
    public GameObject m_pp;
    public GameObject m_tramp;
    public GameObject m_fan;
    public GameObject m_platformHori;
    public GameObject m_platformVert;
    public Button m_ballonBtn;
    public Button m_bombBtn;
    public Button m_tbBtn;
    public Button m_ppBtn;
    public Button m_trampBtn;
    public Button m_fanBtn;
    public Button m_resetButton;
    public Button m_pauseButton;
    public Button m_ptmHori;
    public Button m_ptmVert;
    private bool m_isHeldDown;
    private float m_startPosX;
    private float m_startPosY;
    Vector3 m_mousePos;
    bool m_paused;
    public bool start = false;


    void OnEnable()
    {
       
        //Register Button Events
        m_ballonBtn.onClick.AddListener(() => ButtonCallBack(m_ballonBtn));
        m_bombBtn.onClick.AddListener(() => ButtonCallBack(m_bombBtn));
        m_tbBtn.onClick.AddListener(() => ButtonCallBack(m_tbBtn));
        m_ppBtn.onClick.AddListener(() => ButtonCallBack(m_ppBtn));
        m_trampBtn.onClick.AddListener(() => ButtonCallBack(m_trampBtn));
        m_fanBtn.onClick.AddListener(() => ButtonCallBack(m_fanBtn));
        m_resetButton.onClick.AddListener(() => ButtonCallBack(m_resetButton));
        m_pauseButton.onClick.AddListener(() => ButtonCallBack(m_pauseButton));
        m_ptmHori.onClick.AddListener(() => ButtonCallBack(m_ptmHori));
        m_ptmVert.onClick.AddListener(() => ButtonCallBack(m_ptmVert));
    }
    void Start()
    {
        m_paused = true;
        Time.timeScale = 0;
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

    private void ButtonCallBack(Button t_buttonPressed)
    {
        if(m_paused)
        {
            if (t_buttonPressed == m_ballonBtn)
            {
                Debug.Log("Clicked: " + m_ballonBtn.name);
                Instantiate(m_balloon);

            }

            if (t_buttonPressed == m_bombBtn)
            {
                Debug.Log("Clicked: " + m_bombBtn.name);
                Instantiate(m_bomb);

            }

            if (t_buttonPressed == m_tbBtn)
            {
                Debug.Log("Clicked: " + m_tbBtn.name);
                Instantiate(m_tb);

            }

            if (t_buttonPressed == m_ppBtn)
            {
                Debug.Log("Clicked: " + m_ppBtn.name);
                Instantiate(m_pp);

            }
            if (t_buttonPressed == m_trampBtn)
            {
                Debug.Log("Clicked: " + m_trampBtn.name);
                Instantiate(m_tramp);

            }
            if (t_buttonPressed == m_fanBtn)
            {
                Debug.Log("Clicked: " + m_fanBtn.name);
                Instantiate(m_fan);

            }
            if (t_buttonPressed == m_ptmHori)
            {
                Debug.Log("Clicked: " + m_ptmHori.name);
                Instantiate(m_platformHori);

            }
            if (t_buttonPressed == m_ptmVert)
            {
                Debug.Log("Clicked: " + m_ptmVert.name);
                Instantiate(m_platformVert);

            }
            if (t_buttonPressed == m_resetButton)
            {
                Time.timeScale = 0;
                Debug.Log("Clicked: " + m_resetButton.name);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                m_paused = true;

            }
            if (t_buttonPressed == m_pauseButton)
            {
                Time.timeScale = 1;
                start = true;
                Debug.Log("Clicked: " + m_pauseButton.name);
                m_paused = false;
            }
        }
    }

    public bool startCheck()
    {
        return start;
    }

}
