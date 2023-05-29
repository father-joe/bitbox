using System.Drawing;
using System.Numerics;
namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
	public class Player : IGameObject
	{
		private bool _isDead = false;
		public bool isDead { get { return _isDead; } }
		public Vector2 Velocity { get; set; }
		public Vector2 Position { get; private set; }
        private Vector2 _size = new Vector2(120, 70);
		public Vector2 size { get; private set; }

		public int Number { get; }
        public bool PlayerProjectile { get; }

        // public int Points;

		public Player(Vector2 velocity)
		{
			Velocity = velocity;
			//isDead = false;
            size = _size;
            // Points = 0;
		}
		
		public bool GetIsDead()
		{
			return _isDead;
		}
		
		public void SetIsDead(bool isDead)
		{
			_isDead = isDead;
		}
		
		public void ChangeDirektion(){}

		/*public void Fire()
        {
            Console.WriteLine("Peng");
        }

		public void TrackInvaderProjectile(ref List<Projectile> invaderProjectile) //TODO: delete
        {
            // Logik zur Verfolgung des Spielerprojektils
        }*/
		
	}
}

