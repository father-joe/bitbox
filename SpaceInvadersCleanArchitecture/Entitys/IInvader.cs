using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
	public interface IInvader
	{
        bool IsDead { get; }
        Vector2 InvaderPosition { get; }
        Vector2 Velocity { get; }
        Vector2 size { get; }

        public void Fire();

        public void ChangeDirektion();

        public void TrackPlayerProjectile(ref List<Projectile> playerProjectiles);
    }
}

