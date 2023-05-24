using System;
namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class BarrierController
    {
        private Barrier barrier;
        private List<Projectile> projectiles;

        public BarrierController(int position)
        {
            barrier = new Barrier(position);
            projectiles = new List<Projectile>();
            // Weitere Initialisierungen
        }

        public void TrackProjectiles()
        {
            barrier.TrackProjectile(ref projectiles);
        }
    }
}

