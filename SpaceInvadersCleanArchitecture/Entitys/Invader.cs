using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
    public class Invader : IInvader
    {
        public bool IsDead { get {return _IsDead;} }
        private bool _IsDead = false;

        public Vector2 InvaderPosition { get; private set; }
        public Vector2 Velocity { get; private set; }
        private Vector2 _size = new Vector2(40, 40);
        public Vector2 size { get; private set; }

        public Invader()
        {
            size = _size;
        }

        public Invader(Vector2 position, Vector2 velocity)
        {
            InvaderPosition = position;
            Velocity = velocity;
            _IsDead = false;
            size = _size;
        }

        public void Fire() //TODO: delete
        {
            //Console.WriteLine("Peng");
        }

        public void ChangeDirektion()
        {
            Velocity *= -1;
        }

        public void TrackPlayerProjectile(ref List<Projectile> playerProjectiles) //TODO: delete
        {
            // Logik zur Verfolgung des Spielerprojektils
        }
    }

}

