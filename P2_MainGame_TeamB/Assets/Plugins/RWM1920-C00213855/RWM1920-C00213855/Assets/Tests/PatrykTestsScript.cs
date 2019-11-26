using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PatrykTests
    {
        private GameObject gameObject;
        BombScript bombscript;
        // A Test behaves as an ordinary method
        [SetUp]
        public void Setup()
        {
            gameObject = GameObject.Instantiate(new GameObject());
            bombscript = gameObject.AddComponent<BombScript>();
        }
        [Test]
        public void ActivatingBomb()
        {
            // Use the Assert class to test conditions

            bombscript.m_activate = false;
            bombscript.SetActive(true);
            bool result = bombscript.m_activate;
            bool expectedResult = true;
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public void BombExplodes()
        {
            // Use the Assert class to test conditions
            bombscript.m_activate = false;
            bombscript.SetActive(true);
            bombscript.SetExploded(true);
            bool result = bombscript.m_activate;
            bool expectedResult = true;

            Assert.AreEqual(expectedResult, result);
        }
    }
}
