using System;
namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
	public interface ICollisionController
	{
        public void CheckCollision(ref IMovableObject player, ref IMovableObject[,] invaders, ref IBarrierController[] barriers, ref List<ProjectileController> projectiles);
    }
}

