using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
	public interface IProjectile
	{
        bool PlayerProjectile { get; }
        bool IsDead { get; }

        public Vector2 ProjectilePosition { get; }
        public Vector2 velocity { get; }

        void LifeSpan();
    }
}

