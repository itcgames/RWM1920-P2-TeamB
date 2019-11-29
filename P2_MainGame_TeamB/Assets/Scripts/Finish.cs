using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int SceneToChangeTo = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Goal reached!");
            Application.Quit();
            SceneManager.LoadScene(SceneToChangeTo);
        }
    }
}
