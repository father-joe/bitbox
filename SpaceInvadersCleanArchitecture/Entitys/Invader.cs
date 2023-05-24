using System.Numerics;
//using SFML.Graphics;
//using SFML.System;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
    public class Invader : IInvader
    {
        public bool IsDead { get; private set; }
        //public RectangleShape InvaderRect { get; private set; }
        //public Vector2i InvaderPosition { get; private set; }
        //public Vector2f Velocity { get; private set; }
        //new Vector2f(Globals.windowSize.X / 80, 0);

        public Vector2 InvaderPosition { get; private set; }
        public Vector2 Velocity { get; private set; }

        public Invader(Vector2 position, Vector2 velocity)
        {
            //InvaderRect = new RectangleShape(new Vector2f(40, 40));
            InvaderPosition = position;
            Velocity = velocity;
            IsDead = false;
        }

        public void Fire()
        {

        }

        public void TrackPlayerProjectile(ref List<Projectile> playerProjectiles)
        {
            // Logik zur Verfolgung des Spielerprojektils
        }
    }

}

