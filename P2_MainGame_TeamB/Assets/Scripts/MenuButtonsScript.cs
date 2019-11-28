using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsScript : MonoBehaviour
{
   public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void PlayGame(int SceneToChangeTo)
    {
        SceneManager.LoadScene(1);
        Debug.Log("Quit Game");
    }
}
