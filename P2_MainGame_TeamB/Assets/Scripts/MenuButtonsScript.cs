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

    public void changeScene(int SceneToChangeTo)
    {
        SceneManager.LoadScene(SceneToChangeTo);
        Debug.Log("Quit Game");
    }

}
