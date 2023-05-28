using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys.alt
{
	public interface IInvader
	{
        bool isDead { get; }
        Vector2 InvaderPosition { get; }
        Vector2 Velocity { get; }
        Vector2 size { get; }

        //public void Fire();
        public bool GetIsDead();

        public void SetIsDead(bool isDead);

        public void ChangeDirektion();

        public void TrackPlayerProjectile(ref List<Projectile> playerProjectiles);
    }
}

