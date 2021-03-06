﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace P3.HighScores
{
    public class HighScoreUI :MonoBehaviour
    {
        [SerializeField] private Text entryNameText = null;
        [SerializeField] private Text entryScoreText = null;
        [SerializeField] private Text entryNum = null;

        private int heightOffest = 75;

        public void init(HighScoreEntryData t_entryData, int Yval)
        {
            entryNameText.text = "";
            double timeRnd = System.Math.Round(t_entryData.m_time, 2);
            entryScoreText.text = timeRnd.ToString();

            entryNum.text = (Yval+1).ToString();
            RectTransform transform = GetComponent<RectTransform>();

            Vector3 pos = transform.position;
            pos.y -= heightOffest * Yval;
            transform.position = pos;
            
        }

    }
}
