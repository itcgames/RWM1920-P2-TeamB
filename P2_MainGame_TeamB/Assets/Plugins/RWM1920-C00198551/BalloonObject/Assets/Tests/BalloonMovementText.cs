using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BalloonMovementText
    {
        // A Test behaves as an ordinary method
        [Test]
        public void BalloonMovementTextSimplePasses()
        {
            // Use the Assert class to test conditions
            float force = 100;
            float mass = 1;
            float getVelocity = BalloonMovement.getVelocity(force, mass);
            float expexted = (force - mass) / mass * Time.deltaTime;

            CollectionBase.Equals(expexted, getVelocity);

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator BalloonMovementTextWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
