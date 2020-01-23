using System.IO;
using UnityEngine;

namespace P3.HighScores
{
    public class HighScoreTableScript : MonoBehaviour
    {
        [SerializeField] private int MaxEntries = 8;
        [SerializeField] private Transform highScoreHolderTransform = null;
        [SerializeField] private GameObject ScoreEntryObject = null;

        [Header("Test")]
        [SerializeField] HighScoreEntryData testentryData = new HighScoreEntryData();

        private string savePath => $"{Application.persistentDataPath}/highscores.json";

        private void Start()
        {
            HighScoreSaveData savedScores =  getSavedScores();

            updateUI(savedScores);
        }

        public void addEntry(HighScoreEntryData t_data)
        {
            HighScoreSaveData savedScores = getSavedScores();

                bool scoreAdded = false;

            for (int i = 0;  i < savedScores.highScores.Count; i++)
            {
                if(t_data.m_time > savedScores.highScores[i].m_time)
                {
                    savedScores.highScores.Insert(i, t_data);
                    scoreAdded = true;
                    break;
                }
            }

            if(!scoreAdded && savedScores.highScores.Count < MaxEntries)
            {
                savedScores.highScores.Add(t_data);
            }

            if(savedScores.highScores.Count > MaxEntries)
            {
                savedScores.highScores.RemoveRange(MaxEntries, savedScores.highScores.Count - MaxEntries);
            }

            updateUI(savedScores);

            SaveScores(savedScores);
        }


        private void updateUI( HighScoreSaveData t_savedScores)
        {
            foreach ( Transform child in highScoreHolderTransform)
            {
                Destroy(child.gameObject);
            }

            int e = 0;
            foreach (HighScoreEntryData highScore in t_savedScores.highScores)
            {
                
                Instantiate(ScoreEntryObject, highScoreHolderTransform).
                GetComponent<HighScoreUI>().init(highScore,e );
                e++;
            }
            
        }

        [ContextMenu("Add Test Item")]
        public void AddTestEntry()
        {
            addEntry(testentryData);
        }

        private HighScoreSaveData getSavedScores()
        {
            if(!File.Exists(savePath))
            {
                File.Create(savePath).Dispose();
                return new HighScoreSaveData();
            }
            using(StreamReader stream = new StreamReader(savePath))
            {
                string json = stream.ReadToEnd();
                return JsonUtility.FromJson<HighScoreSaveData>(json);
            }
        }

        private void SaveScores(HighScoreSaveData t_saveData)
        {
            using (StreamWriter stream = new StreamWriter(savePath))
            {
                string json = JsonUtility.ToJson(t_saveData, true);
                stream.Write(json);
            }
        }
    }
}
