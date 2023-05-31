namespace bitbox.SpaceInvadersCleanArchitecture.Application
{
	public interface ICollisionController
	{
		public void CheckCollision( IMovableObject player,  IMovableObject[,] invaders,  IBarrierController[] barriers,  List<IMovableObject> projectiles);
    }
}

