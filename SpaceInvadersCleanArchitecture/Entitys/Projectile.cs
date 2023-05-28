using System.Numerics;
using SFML.Graphics;
using SFML.System;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
	public class Projectile : IGameObject
	{
        private bool _playerProjectile = false;
        public bool PlayerProjectile { get {return _playerProjectile; } }

        private bool _isDead = false;
        public bool isDead { get { return _isDead; } }

        private IGameWindow window = new GameWindow();

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
        
        public void SetIsDead(bool isDead)
        {
            _isDead = isDead;
        }

        public bool GetIsDead()
        {
            return _isDead;
        }
        
        public void ChangeDirektion(){}
    }
}

