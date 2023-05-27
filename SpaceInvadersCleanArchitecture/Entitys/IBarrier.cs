using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
    public interface IBarrier
    {
        int BarrierPosition { get; }
        Vector2 size { get;  }

        public void TrackProjectile(ref List<Projectile> playerProjectiles);
    }
}