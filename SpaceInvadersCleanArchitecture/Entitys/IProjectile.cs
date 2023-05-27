using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
	public interface IProjectile
	{
        bool PlayerProjectile { get; }

        public void SetIsDead(bool isDead);
        public bool isDead { get; }
        public bool GetIsDead();

        public Vector2 ProjectilePosition { get; }
        public Vector2 velocity { get; }
    }
}

