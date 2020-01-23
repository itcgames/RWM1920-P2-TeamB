using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace P3.HighScores
{
    public class Finish : MonoBehaviour
    {

        private GameObject timer;
        private TimerController tScript;

        private float finalTime = 0.0f;

        private HighScoreTableScript Tablescript;

        private HighScoreEntryData data = new HighScoreEntryData();

        public int SceneToChangeTo = 0;
        public int FinalSceneIndex = 5;

        GameObject[] goArray;
        GameObject rootGo;
        private void Awake()
        {
            timer =  GameObject.Find("TimerController");
            tScript = timer.GetComponent<TimerController>();
            Tablescript = gameObject.GetComponent<HighScoreTableScript>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Goal reached!");
                if (SceneToChangeTo == FinalSceneIndex)
                {
                    finalTime = tScript.m_timer;
                    data.m_name = "Test";
                    data.m_time = tScript.m_timer;
                    Tablescript.addEntry(data);
                }
                SceneManager.LoadScene(SceneToChangeTo);
            }
        }

    }
}
