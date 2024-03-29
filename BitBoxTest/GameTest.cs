﻿using bitbox.SpaceInvadersCleanArchitecture.Presentation;
using bitbox.SpaceInvadersCleanArchitecture.Application;
using Moq;

namespace BitBoxTest
{
	public class GameTest
	{
        [Test]
        public void Game_Over_Player_Test()
		{
            //Arrange
            var game = new Game();

            Mock<IMovableObject> invaderControllerMock = new Mock<IMovableObject>();            
            IMovableObject[,] invaderControllerMockArray = new IMovableObject[,] { { invaderControllerMock.Object } };

            Mock<IMovableObject> playerControllerMock = new Mock<IMovableObject>();

            var player = playerControllerMock.Object;
            player = null;

            //Act           
            game.CheckIfGameOver(player, invaderControllerMockArray);

            //Assert:
            Assert.That(game.gameOver, Is.EqualTo(true));
            Mock.Verify(invaderControllerMock);
            Mock.Verify(playerControllerMock);
        }

        [Test]
        public void Game_Over_Invader_Test()
        {
            //Arrange
            var game = new Game();

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
            Mock.Verify(invaderControllerMock);
            Mock.Verify(playerControllerMock);
        }
    }
}

