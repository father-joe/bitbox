using System;
using bitbox.SpaceInvadersCleanArchitecture.Logic;
using bitbox.SpaceInvadersCleanArchitecture.UseCases;
using static NUnit.Framework.Constraints.Tolerance;

namespace BitBoxTest
{
	public class GameTest
	{
        [Test]
        public void Game_Over_Player_Test()
		{
            //Arrange
            var game = new TestGame();
            IMovableObject playerController = new PlayerController();
            IMovableObject[,] invaderController = new InvaderController[1, 1];
            invaderController[0, 0] = new InvaderController();
            playerController = null;


            //Act
            game.CheckIfGameOver(ref playerController, ref invaderController);

            //Assert:
            Assert.That(game.gameOver, Is.EqualTo(true));
        }

        [Test]
        public void Game_Over_Invader_Test()
        {
            // Arrange
            var game = new TestGame();
            IMovableObject playerController = new PlayerController();
            IMovableObject[,] invaderController = new InvaderController[1,1];            
            invaderController[0, 0] = new InvaderController();
            invaderController[0, 0] = null;
            playerController = new PlayerController();


            //Act
            game.CheckIfGameOver(ref playerController, ref invaderController);

            //Assert:
            Assert.That(game.gameOver, Is.EqualTo(true));
        }
    }
}

