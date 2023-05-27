using System;
namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
	public interface ICollisionController
	{
        public void CheckCollision(ref IPlayerController player, ref IInvaderController[,] invaders, ref IBarrierController[] barriers, ref List<ProjectileController> projectiles);
    }
}

