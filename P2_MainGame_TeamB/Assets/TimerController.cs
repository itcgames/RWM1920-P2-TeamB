using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class TimerController : MonoBehaviour
{
    public float m_timer;
    public Text m_timerText;
    private bool m_isTimerActive;

    void Start()
    {
        m_isTimerActive = true;
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (GameObject.Find(gameObject.name) &&
            GameObject.Find(gameObject.name) !=
            this.gameObject)
        {
            Destroy(GameObject.Find(gameObject.name));
        }
    }
    void Update()
    {
        if (m_isTimerActive)
        {
            m_timer += Time.deltaTime;
            m_timerText.text = "Timer:" + m_timer.ToString("f0");

        }
    }
}
