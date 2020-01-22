using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace P3.HighScores

{
    [Serializable]
    public class HighScoreSaveData
    {
        public List<HighScoreEntryData> highScores = new List<HighScoreEntryData>();
    }
}
