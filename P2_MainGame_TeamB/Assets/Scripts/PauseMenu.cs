using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private CameraFollow camera;

    private bool pause;
    private bool start;

    public void Start()
    {
        pauseMenu.SetActive(false);
        pause = false;
        start = camera.start;
    }

    public void Pause()
    {
        if (!pause)
        {
            pause = true;
        }
        else
        {
            pause = false;
        }

        Debug.Log(Time.timeScale);
    }

    private void Update()
    {
        if (start)
        {
            if (Input.GetKeyDown("escape"))
            {
                if (!pause)
                {
                    pause = true;
                }
                else
                {
                    pause = false;
                }
            }

            if (pause)
            {
                Time.timeScale = 0.0f;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void closePauseMenu()
    {
        pause = false;
    }
}
