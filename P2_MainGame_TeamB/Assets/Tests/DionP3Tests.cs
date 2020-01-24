using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class DionP3Tests
    {
        GameObject light, bg;

        [SetUp]
        public void Setup()
        {
            light = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Light"));
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(light);
        }

        [Test]
        public void LightEmittsLight()
        {
            Assert.True(light.GetComponent<Light>().enabled);
        }

    }
}
