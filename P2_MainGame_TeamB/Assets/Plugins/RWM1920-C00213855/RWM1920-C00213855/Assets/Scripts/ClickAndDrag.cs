using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    private bool m_isHeldDown;
    private float m_startPosX;
    private float m_startPosY;
    Vector3 m_mousePos;

    // Update is called once per frame
    void Update()
    {
        if (m_isHeldDown)
        {

            m_mousePos = Input.mousePosition;
            m_mousePos = Camera.main.ScreenToWorldPoint(m_mousePos);


            gameObject.transform.localPosition = new Vector3(m_mousePos.x - m_startPosX,
                m_mousePos.y - m_startPosY, 0);
        }
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
}