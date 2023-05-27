using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
    public class SBarrier : IBarrier
    {
        public int BarrierPosition { get; private set; }
        private Vector2 _size = new Vector2(120, 70);
        public Vector2 size { get; private set; }

        public SBarrier()
        {
            size = _size;
        }

        public SBarrier(int position)
        {
            BarrierPosition = position;
            size = _size;
        }

        public void TrackProjectile(ref List<Projectile> projectiles) //TODO: delet
        {
            // Logik zum Verfolgen des Projektils
        }
    }
}

