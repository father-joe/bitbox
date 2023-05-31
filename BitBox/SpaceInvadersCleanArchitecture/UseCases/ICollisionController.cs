namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
	public interface ICollisionController
	{
		public void CheckCollision( IMovableObject player,  IMovableObject[,] invaders,  IBarrierController[] barriers,  List<IMovableObject> projectiles);
    }
}

