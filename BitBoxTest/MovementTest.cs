using Moq;
using bitbox.SpaceInvadersCleanArchitecture.Application;
using bitbox.SpaceInvadersCleanArchitecture.Domain;
using System.Numerics;

namespace BitBoxTest
{
    public class MovementTest
    {
        [Test]
        public void Player_Movement_Test()
        {
            //Arrange
            Vector2 initialPosition = new Vector2(0, 0);
            Vector2 targetPosition = new Vector2(3, 0);

            var playerController = new PlayerController();
            playerController.SetPosition(initialPosition);


            //Act
            playerController.Update(1);

            //Assert
            Assert.That(playerController.position, Is.EqualTo(targetPosition));
        }

        [Test]
        public void Invader_Movement_Test()
        {
            //Arrange
            Vector2 initialPosition = new Vector2(100, 100);
            Vector2 targetPosition = new Vector2(103, 100);
            Vector2 initialVelocity = new Vector2(3, 0);

            var invaderController = new InvaderController(initialPosition, initialVelocity, 0, 0);
            invaderController.SetPosition(initialPosition);
            invaderController.duration = 2000;

            //Act
            invaderController.MoveInvader(1);

            //Assert
            Assert.That(invaderController.position, Is.EqualTo(targetPosition));
        }

        [Test]
        public void Invader_Change_Level_Test()
        {
            //Arrange
            Vector2 initSize = new Vector2(40, 40);
            Mock<IGameObject> invaderMock = new Mock<IGameObject>();
            invaderMock.Setup(x => x.size).Returns(initSize);

            Mock<IWindowController> windowControllerMock = new Mock<IWindowController>();
            windowControllerMock.Setup(x => x.GetWindowHight()).Returns(960);

            Vector2 initialPosition = new Vector2(100, 100);           
            Vector2 initialVelocity = new Vector2();

            var invaderController = new InvaderController(initialPosition, initialVelocity, 0, 0);
            invaderController.SetPosition(initialPosition);

            float targetPositionY = ((windowControllerMock.Object.GetWindowHight() / invaderMock.Object.size.Y * 3) * 100) + 33 * 1;
            Vector2 targetPosition = new Vector2(100, targetPositionY);

            //Act
            invaderController.UpdateInvaderLevel();
            
            //Assert
            Assert.That(invaderController.position, Is.EqualTo(targetPosition));
            Mock.Verify(invaderMock);
            Mock.Verify(windowControllerMock);
        }

        [Test]
        public void Projectile_Movement_Test()
        {
            //Arrange
            Vector2 initialPosition = new Vector2(0, 0);
            bool isPlayerProjetile = false;

            var projectileController = new ProjectileController(initialPosition, isPlayerProjetile);
            
            Vector2 targetPosition = new Vector2(0, 05f);

            //Act
            projectileController.Update(0);

            //Assert
            Assert.That(projectileController.position, Is.EqualTo(targetPosition));
        }
    }
}
