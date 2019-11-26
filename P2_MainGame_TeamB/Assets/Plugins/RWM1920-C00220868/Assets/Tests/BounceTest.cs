using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BounceTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void BounceTestSimplePasses()
        {
            //Bounce bounce = new Bounce();
            //bounce.bounce(new GameObject());
            Assert.AreEqual(1, 1);
        }

        // A UnityTest behaves like a coroutine in Play Mode.
        [UnityTest]
        public IEnumerator BounceTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            GameObject trampoline = MonoBehaviour.Instantiate(Resources.Load<GameObject>("./Prefabs/Trampoline"));
            Vector3 initialPos = trampoline.transform.position;
            yield return new WaitForSeconds(1);
            Vector3 endPos = trampoline.transform.position;
            Assert.Greater(endPos.y, initialPos.y);
        }
    }
}
