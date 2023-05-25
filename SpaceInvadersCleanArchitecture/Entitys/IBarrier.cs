using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
    public interface IBarrier
    {
        int BarrierPosition { get; }

        public void TrackProjectile(ref List<Projectile> playerProjectiles);
    }
}