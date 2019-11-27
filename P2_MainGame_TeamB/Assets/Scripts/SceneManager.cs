using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public GameObject bomb;
    public Button myButton;

    private bool m_isHeldDown;
    private float m_startPosX;
    private float m_startPosY;
    Vector3 m_mousePos;
    void OnEnable()
    {

        myButton.onClick.AddListener(TaskOnClick);//adds a listener for when you click the button

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
    public void AddObject()
    {
        Instantiate(bomb);
        m_isHeldDown = true;

    }

    void TaskOnClick()
    {
        AddObject();
        Debug.Log("You have clicked the button!");
    }
}
