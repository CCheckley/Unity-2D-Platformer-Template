using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SideScrollingCharacterTests
    {
        SideScrollingCharacter sideScrollingCharacter;

        [SetUp]
        public void Setup()
        {
            GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Characters/SideScrollingCharacter"));
            sideScrollingCharacter = player.GetComponent<SideScrollingCharacter>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(sideScrollingCharacter.gameObject);
        }

        [UnityTest]
        public IEnumerator SideScrollingCharacterPositionChangesOnInput()
        {
            Vector2 playerInitialPosition = sideScrollingCharacter.transform.position;

            sideScrollingCharacter.Move(1.0f, true);

            yield return new WaitForSeconds(0.1f);

            Assert.AreNotEqual(playerInitialPosition, sideScrollingCharacter.transform.position);
        }
    }
}