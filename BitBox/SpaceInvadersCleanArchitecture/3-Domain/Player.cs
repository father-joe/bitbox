using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Domain
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

		public Player(Vector2 velocity)
		{
			Velocity = velocity;
            size = _size;
		}
		
		public bool GetIsDead()
		{
			return _isDead;
		}

        public void SetPlayerProjectile(bool isPlayerProjectile)
        {
			throw new NotImplementedException();
        }

        public void SetIsDead(bool isDead)
		{
			_isDead = isDead;
		}
		
		public void ChangeDirektion(){ throw new NotImplementedException(); }

	}
}

