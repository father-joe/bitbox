using bitbox.SpaceInvadersCleanArchitecture.Application;
using Moq;
using System.Numerics;

namespace BitBoxTest
{
    public class CollisionTest
    {
        [Test]
        public void Collision_With_Border_Test()
        {
            //Arrange
            Vector2 position = new Vector2(10, 1920 / 2);

            Mock<IMovableObject> projectileControllerMock = new Mock<IMovableObject>();          
            projectileControllerMock.Setup(x => x.position).Returns(position);
            List<IMovableObject> projectileControllerMockList = new List<IMovableObject> { projectileControllerMock.Object };

            var collisionController = new CollisionController();
            
            //Act
            collisionController.CheckCollisionWithBorders(projectileControllerMockList);

            //Assert
            Assert.That(collisionController.collisionDetected, Is.EqualTo(true));
            Mock.Verify(projectileControllerMock);

        }

        [Test]
        public void Collision_With_Barrier_Test()
        {
            //Arrange
            Vector2 position = new Vector2(10, 50);

            Mock<IMovableObject> projectileControllerMock = new Mock<IMovableObject>();
            projectileControllerMock.Setup(x => x.position).Returns(position);            
            List<IMovableObject> projectileControllerMockList = new List<IMovableObject> { projectileControllerMock.Object };

            Mock<IBarrierController> barrierControllerMock = new Mock<IBarrierController>();
            barrierControllerMock.Setup(x => x.position).Returns(position);            
            IBarrierController[] barrierControllerMockArray = new IBarrierController[] { barrierControllerMock.Object };

            var collisinController = new CollisionController();

            //Act
            collisinController.CheckCollisionWithBarriers(barrierControllerMockArray, projectileControllerMockList);

            //Assert
            Assert.That(collisinController.collisionDetected, Is.EqualTo(true));
            Mock.Verify(projectileControllerMock);
            Mock.Verify(barrierControllerMock);
        }

        [Test]
        public void Collision_With_Player_Test()
        {
            //Arrange
            Vector2 position = new Vector2(10, 50);

            Mock<IMovableObject> projectileControllerMock = new Mock<IMovableObject>();
            projectileControllerMock.Setup(x => x.position).Returns(position);
            List<IMovableObject> projectileControllerMockList = new List<IMovableObject> { projectileControllerMock.Object };

            Mock<IMovableObject> playerControllerMock = new Mock<IMovableObject>();
            playerControllerMock.Setup(x => x.position).Returns(position);

            var collisinController = new CollisionController();

            //Act            
            collisinController.CheckCollisionWithPlayer(playerControllerMock.Object, projectileControllerMockList);

            //Assert
            Assert.That(collisinController.collisionDetected, Is.EqualTo(true));
            Mock.Verify(playerControllerMock);
            Mock.Verify(projectileControllerMock);
        }

        [Test]
        public void Collision_With_Invader_Test()
        {
            //Arrange
            Vector2 positionInvader = new Vector2(10, 50);
            Vector2 size = new Vector2(40, 40);

            Mock<IMovableObject> invaderControllerMock = new Mock<IMovableObject>();
            invaderControllerMock.Setup(x => x.position).Returns(positionInvader);
            invaderControllerMock.Setup(x => x.size).Returns(size);
            IMovableObject[,] invaderControllerMockArray = new IMovableObject[,] { { invaderControllerMock.Object } };

            Vector2 positionProjectile = new Vector2(10, 50);            
            Mock<IMovableObject> projectileControllerMock = new Mock<IMovableObject>();            
            projectileControllerMock.Setup(x => x.position).Returns(positionProjectile);
            projectileControllerMock.Setup(x => x.isPlayerProjectile).Returns(true);            
            
            List<IMovableObject> projectileControllerMockList = new List<IMovableObject> { projectileControllerMock.Object };

            var collisinController = new CollisionController();

            //Act
            collisinController.CheckCollisionWithInvader(invaderControllerMockArray, projectileControllerMockList);

            //Assert
            Assert.That(collisinController.collisionDetected, Is.EqualTo(true));
            Mock.Verify(projectileControllerMock);
            Mock.Verify(invaderControllerMock);
        }
    }
}

