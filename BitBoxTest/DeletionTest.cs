using System;
using bitbox.SpaceInvadersCleanArchitecture.Logic;
using bitbox.SpaceInvadersCleanArchitecture.UseCases;

namespace BitboxTests
{
	public class DeletionTest
	{
		[Test]
		public void Delet_Projectile_Test()
		{
            //Arrange
            var game = new TestGame();
            List<ProjectileController> projectileControllers = new List<ProjectileController>();
            projectileControllers.Add(new ProjectileController());
			projectileControllers[0].SetIsDead(true);

            //Act
            game.DeleteProjectiles(ref projectileControllers);

            //Assert:
            Assert.Null(projectileControllers[0]);
        }

		[Test]
		public void Delet_Invader_Test()
		{
            //Arrange
            var game = new TestGame();
            IMovableObject[,] invaderController = new InvaderController[1, 1];
			invaderController[0, 0] = new InvaderController();
			invaderController[0, 0].SetIsDead(true);

            //Act
            game.DeleteInvaders(ref invaderController);

            //Assert:
            Assert.Null(invaderController[0,0]);
        }

		[Test]
		public void Delet_Player_Test()
		{
            //Arrange
            var game = new TestGame();
            IMovableObject playerController = new PlayerController();
			playerController.SetIsDead(true);

            //Act
            game.DeletePlayer(ref playerController);

            //Assert:
            Assert.Null(playerController);
        }
	}
}

