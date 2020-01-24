using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;

namespace Tests
{
    [TestFixture]
    public class EoinP3Tests
    {

        private string SavePath => $"{Application.persistentDataPath}/highscoresTest.json";

        [SetUp]
        public void Setup()
        {
            
        }

        [UnityTest]
        public IEnumerator ReadingWritingJSonTest()
        {
            string json = JsonUtility.ToJson("WritingTest", true);
            File.WriteAllText(SavePath, json);

            string newJson = JsonUtility.FromJson<string>(json);

            yield return null;
        }

    }
}
