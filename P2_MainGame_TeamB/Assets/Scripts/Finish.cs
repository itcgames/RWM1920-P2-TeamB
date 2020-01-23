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
        public HighScoreTable tableScript;

        public HighScoreEntryData data = new HighScoreEntryData();

        public int SceneToChangeTo = 0;
        public int FinalSceneIndex = 5;

        private void Awake()
        {
            timer =  GameObject.Find("TimerController");
            tScript = timer.GetComponent<TimerController>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Goal reached!");
                SceneManager.LoadScene(SceneToChangeTo);
                finalTime = tScript.m_timer;
                data.m_name = "Test";
                data.m_time = tScript.m_timer;
                tableScript.addEntry(data);
            }
        }

    }
}
