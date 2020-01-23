using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
        public class HighScoreTest
    {

        GameObject Table;
        [SetUp]
        public void Setup()
        {
            Table = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/HighScore_Table/HighScoreTable"));
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(Table);    
        }


        // A Test behaves as an ordinary method
        [Test]
        public void HighScoreTestSimplePasses()
        {

            Table.GetComponent<HighScoreScript>().addEntry();

        }

    }
}
