using bitbox.SpaceInvadersCleanArchitecture.Logic;
using bitbox.SpaceInvadersCleanArchitecture.UseCases;
using Moq;

namespace BitBoxTest
{
	public class DeletionTest
	{

        [Test]
		public void Delet_Projectile_Test()
		{
            //Arrange
            var game = new TestGame();

            Mock<IMovableObject> projectileControllerMock = new Mock<IMovableObject>();
            projectileControllerMock.Setup(x => x.isDead).Returns(true);
            List<IMovableObject> projectileControllerMockList = new List<IMovableObject> { projectileControllerMock.Object };

            //Act
            game.DeleteProjectiles(projectileControllerMockList);

            //Assert:
            Assert.Null(projectileControllerMockList[0]);
        }

        [Test]
		public void Delet_Invader_Test()
		{
            //Arrange
            Mock<IMovableObject> invaderControllerMock = new Mock<IMovableObject>();
            invaderControllerMock.Setup(x => x.isDead).Returns(true);
            IMovableObject[,] invaderControllerMockArray = new IMovableObject[,] { { invaderControllerMock.Object } };

            var game = new TestGame();

            //Act
            game.DeleteInvaders(invaderControllerMockArray);

            //Assert
            Assert.Null(invaderControllerMockArray[0, 0]);
        }

		[Test]
		public void Delet_Player_Test()
		{
            //Arrange
            var game = new TestGame();
            IMovableObject playerController = new PlayerController();
			playerController.SetIsDead(true);

            //Act
            var deletetPlayer = game.DeletePlayer(playerController);

            //Assert:
            Assert.Null(deletetPlayer);
        }
    }
}

