using bitbox.SpaceInvadersCleanArchitecture.UseCases;

namespace BitboxTests
{
    public class CollisionTest
    {
        [Test]
        public void Collision_With_Border_Test()
        {            
            //Arrange
            var collisionController = new CollisionController();
            List<ProjectileController> projectileControllers = new List<ProjectileController>();
            projectileControllers.Add(new ProjectileController(new System.Numerics.Vector2(0, 1920 / 2), true));

            //Act
            collisionController.CheckCollisionWithBorders(ref projectileControllers);

            //Assert
            Assert.That(projectileControllers[0].isDead, Is.EqualTo(true));
        }

        [Test]
        public void Collision_With_Barrier_Test()
        {
            //Arrange
            var collisionController = new CollisionController();

            List<ProjectileController> projectileControllers = new List<ProjectileController>();
            projectileControllers.Add(new ProjectileController(new System.Numerics.Vector2(60, 600), false));

            IBarrierController[] barrierControllers = new BarrierController[1];
            barrierControllers[0] = new BarrierController(0);

            //Act
            collisionController.CheckCollisionWithBarriers(ref barrierControllers, ref projectileControllers);

            //Assert:
            Assert.That(projectileControllers[0].isDead, Is.EqualTo(true));
        }

        [Test]
        public void Collision_With_Player_Test()
        {
            //Arrange
            var collisionController = new CollisionController();
            List<ProjectileController> projectileControllers = new List<ProjectileController>();
            projectileControllers.Add(new ProjectileController(new System.Numerics.Vector2(390, 820), false));

            IMovableObject playerController = new PlayerController();

            //Act
            collisionController.CheckCollisionWithPlayer(ref playerController, ref projectileControllers);

            //Assert:
            Assert.That(projectileControllers[0].isDead, Is.EqualTo(true));
            Assert.That(playerController.isDead, Is.EqualTo(true));
        }

        [Test]
        public void Collision_With_Invader_Test()
        {
            //Arrange
            var collisionController = new CollisionController();

            List<ProjectileController> projectileControllers = new List<ProjectileController>();
            projectileControllers.Add(new ProjectileController(new System.Numerics.Vector2(80, 33), true));

            IMovableObject[,] invaderController = new InvaderController[1, 1];
            invaderController[0, 0] = new InvaderController(new System.Numerics.Vector2(0, 0), new System.Numerics.Vector2(3, 0), 0, 0);

            //Act
            collisionController.CheckCollisionWithInvader(ref invaderController, ref projectileControllers);

            //Assert:
            Assert.That(projectileControllers[0].isDead, Is.EqualTo(true));
            Assert.That(invaderController[0, 0].isDead, Is.EqualTo(true));
        }
    }
}

