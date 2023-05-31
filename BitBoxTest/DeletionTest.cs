using bitbox.SpaceInvadersCleanArchitecture.Logic;
using bitbox.SpaceInvadersCleanArchitecture.Application;
using Moq;

namespace BitBoxTest
{
	public class DeletionTest
	{

        [Test]
		public void Delet_Projectile_Test()
		{
            //Arrange
            var game = new Game();

            Mock<IMovableObject> projectileControllerMock = new Mock<IMovableObject>();
            projectileControllerMock.Setup(x => x.isDead).Returns(true);
            List<IMovableObject> projectileControllerMockList = new List<IMovableObject> { projectileControllerMock.Object };

            //Act
            game.DeleteProjectiles(projectileControllerMockList);

            //Assert:
            Assert.Null(projectileControllerMockList[0]);
            Mock.Verify(projectileControllerMock);
        }

        [Test]
		public void Delet_Invader_Test()
		{
            //Arrange
            var game = new Game();

            Mock<IMovableObject> invaderControllerMock = new Mock<IMovableObject>();
            invaderControllerMock.Setup(x => x.isDead).Returns(true);
            IMovableObject[,] invaderControllerMockArray = new IMovableObject[,] { { invaderControllerMock.Object } };        

            //Act
            game.DeleteInvaders(invaderControllerMockArray);

            //Assert
            Assert.Null(invaderControllerMockArray[0, 0]);
            Mock.Verify(invaderControllerMock);
        }

		[Test]
		public void Delet_Player_Test()
		{
            //Arrange
            var game = new Game();
            Mock<IMovableObject> playerControllerMock = new Mock<IMovableObject>();
            playerControllerMock.Setup(x => x.isDead).Returns(true);

            //Act
            var deletetPlayer = game.DeletePlayer(playerControllerMock.Object);

            //Assert:
            Assert.Null(deletetPlayer);
            Mock.Verify(playerControllerMock);
        }
    }
}

