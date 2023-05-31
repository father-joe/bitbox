using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Domain
{
	public class Projectile : IGameObject
	{
        private bool _playerProjectile = false;
        public bool PlayerProjectile { get {return _playerProjectile; } }

        private bool _isDead = false;
        public bool isDead { get { return _isDead; } }

        private Vector2 _velocity = new Vector2(0, 05f);
        public Vector2 Position { get; private set; }
        private Vector2 _size = new Vector2(5, 20); 
        public Vector2 size { get; private set; }
        public Vector2 Velocity { get {return _velocity; } }
        
        public int Number { get; }

        public Projectile()
        {
            size = _size;
        }

        public Projectile(Vector2 position, Vector2 velocity, bool isPlayerProjectile)
        {
            _playerProjectile = isPlayerProjectile;    
            Position = position;
            _velocity = velocity;
            size = _size;
        }

        public void SetPlayerProjectile(bool isPlayerProjectile)
        {
            _playerProjectile = isPlayerProjectile;
        }
        
        public void SetIsDead(bool isDead)
        {
            _isDead = isDead;
        }

        public bool GetIsDead()
        {
            return _isDead;
        }
        
        public void ChangeDirektion()
        {
            throw new NotImplementedException();
        }
    }
}

