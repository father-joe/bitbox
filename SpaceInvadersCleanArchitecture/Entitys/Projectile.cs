using System.Numerics;
using SFML.Graphics;
using SFML.System;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
	public class Projectile : IProjectile
	{
        private bool _playerProjectile = false;
        public bool PlayerProjectile { get {return _playerProjectile; } }

        private bool _isDead = false;
        public bool isDead { get { return _isDead; } }

        public void SetIsDead(bool isDead)
        {
            _isDead = isDead;
        }

        public bool GetIsDead()
        {
            return _isDead;
        }

        private IGameWindow window = new GameWindow();

        private Vector2 _velocity = new Vector2(0, 05f);
        public Vector2 ProjectilePosition { get; private set; }
        public Vector2 velocity { get {return _velocity; } }

        public Projectile(Vector2 position, Vector2 velocity, bool isPlayerProjectile)
        {
            _playerProjectile = isPlayerProjectile;    
            ProjectilePosition = position;
            _velocity = velocity;
        }
    }
}

