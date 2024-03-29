﻿using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Domain
{
    public class Invader : IGameObject
    {
        private bool _isDead = false;
        public bool isDead { get { return _isDead; } }
        
        public int Number { get; }
        public bool PlayerProjectile { get; }

        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }
        private Vector2 _size = new Vector2(40, 40);
        public Vector2 size { get; private set; }

        public Invader()
        {
            size = _size;
        }

        public Invader(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
            size = _size;
        }

        public void SetPlayerProjectile(bool isPlayerProjectile)
        {
            throw new NotImplementedException();
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
            Velocity *= -1;
        }
    }
}

