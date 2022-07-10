using System.Collections;
using HoloFit_VrTest.Abstracts.Controllers;
using HoloFit_VrTest.Abstracts.Inputs;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NSubstitute;

namespace Player
{
    public class player_move
    {
        [UnitySetUp]
        public IEnumerator Setup()
        {
            yield return SceneManager.LoadSceneAsync("MovementTest");
        }
        
        [UnityTest]
        [TestCase(-1,0, ExpectedResult = (IEnumerator)null)]
        [TestCase(1,0, ExpectedResult = (IEnumerator)null)]
        [TestCase(0,-1, ExpectedResult = (IEnumerator)null)]
        [TestCase(0,1, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_can_move_left_right_forward_back(float x, float z)
        {
            //Arrange
            var player = GameObject.FindWithTag("Player").GetComponent<IPlayerController>();
            player.Input = Substitute.For<IInputReader>();
            
            //Act
            player.transform.position = new Vector3(0f, player.transform.position.y, 0f);

            for (int i = 0; i < 20; i++)
            {
                player.Input.MoveDirection.Returns(new Vector3(x, 0f, z));    
                yield return null;
            }
            
            //Assert
            if (x != 0)
            {
                Assert.AreNotEqual(x, player.transform.position.x);    
            }
            else if (z != 0)
            {
                Assert.AreNotEqual(x, player.transform.position.z);
            }
        }
    }    
}

