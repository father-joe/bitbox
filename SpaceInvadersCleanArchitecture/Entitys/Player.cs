using System.Numerics;
namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
	public class Player:IPlayer
	{
		public Vector2 Velocity { get; set; }
        private Vector2 _size = new Vector2(120, 70);
		public Vector2 size { get; private set; }

        public bool isDead { get; set; }

		public Player(Vector2 velocity)
		{
			Velocity = velocity;
			isDead = false;
            size = _size;
        }

		public void Fire()
        {
            Console.WriteLine("Peng");
        }

		public void TrackInvaderProjectile(ref List<Projectile> invaderProjectile) //TODO: delete
        {
            // Logik zur Verfolgung des Spielerprojektils
        }
		
	}
}

