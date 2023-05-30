using System;
using System.Drawing;
using bitbox.SpaceInvadersCleanArchitecture.Logic;
using bitbox.SpaceInvadersCleanArchitecture.UseCases;
using Moq;
using static NUnit.Framework.Constraints.Tolerance;

namespace BitboxTests
{
	public class GameTest
	{
        [Test]
        public void Game_Over_Player_Test()
		{
            //Arrange
            var game = new TestGame();

            Mock<IMovableObject> invaderControllerMock = new Mock<IMovableObject>();            
            IMovableObject[,] invaderControllerMockArray = new IMovableObject[,] { { invaderControllerMock.Object } };

            Mock<IMovableObject> playerControllerMock = new Mock<IMovableObject>();

            var player = playerControllerMock.Object;
            player = null;

            //Act           
            game.CheckIfGameOver(player, invaderControllerMockArray);

            //Assert:
            Assert.That(game.gameOver, Is.EqualTo(true));
        }

        [Test]
        public void Game_Over_Invader_Test()
        {
            //Arrange
            var game = new TestGame();

            Mock<IMovableObject> invaderControllerMock = new Mock<IMovableObject>();
            var invader = invaderControllerMock.Object;
            invader = null;
            var invader2 = invaderControllerMock.Object;
            invader2 = null;
            IMovableObject[,] invaderControllerMockArray = new IMovableObject[,] { { invader }, { invader2 } };

            Mock<IMovableObject> playerControllerMock = new Mock<IMovableObject>();           

            //Act           
            game.CheckIfGameOver(playerControllerMock.Object, invaderControllerMockArray);

            //Assert:
            Assert.That(game.gameOver, Is.EqualTo(true));
        }
    }
}

