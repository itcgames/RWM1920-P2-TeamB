using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionManagment : MonoBehaviour
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
    public Button m_startButton;
    public Button m_resetButton;
    private bool m_isHeldDown;
    private float m_startPosX;
    private float m_startPosY;
    Vector3 m_mousePos;
    
    void OnEnable()
    {
       
        //Register Button Events
        m_ballonBtn.onClick.AddListener(() => ButtonCallBack(m_ballonBtn));
        m_bombBtn.onClick.AddListener(() => ButtonCallBack(m_bombBtn));
        m_tbBtn.onClick.AddListener(() => ButtonCallBack(m_tbBtn));
        m_ppBtn.onClick.AddListener(() => ButtonCallBack(m_ppBtn));
        m_trampBtn.onClick.AddListener(() => ButtonCallBack(m_trampBtn));
        m_fanBtn.onClick.AddListener(() => ButtonCallBack(m_fanBtn));
        m_startButton.onClick.AddListener(() => ButtonCallBack(m_startButton));
        m_resetButton.onClick.AddListener(() => ButtonCallBack(m_resetButton));
    }
    private void Awake()
    {
    }
    void Start()
    {
        
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
        if (t_buttonPressed == m_startButton)
        {
            
            Debug.Log("Clicked: " + m_startButton.name);
            //m_balloon.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }
        if (t_buttonPressed == m_resetButton)
        {

            Debug.Log("Clicked: " + m_resetButton.name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
