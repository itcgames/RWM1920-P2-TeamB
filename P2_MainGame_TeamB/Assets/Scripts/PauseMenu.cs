using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public CameraFollow camera;
    public SceneManagerr scene;

    private bool pause;
    private bool start;

    public void Start()
    {
        pauseMenu.SetActive(false);
        pause = false;
        if (camera != null)
        {
            start = camera.startCheck();
        }
        else if (scene != null)
        {
            start = scene.startCheck();
        }
        
    }

    public void Pause()
    {
        if (camera != null)
        {
            start = camera.startCheck();
        }
        else if (scene != null)
        {
            start = scene.startCheck();
        }

        Debug.Log(start);

        if (!pause)
        {
            pause = true;
        }
        else
        {
            pause = false;
        }

        Debug.Log(Time.timeScale);
        Debug.Log(start);
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
