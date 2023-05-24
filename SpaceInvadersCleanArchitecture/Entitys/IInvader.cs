using System.Numerics;
//using SFML.System;
//using SFML.System;
//using SFML.Graphics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
	public interface IInvader
	{
        bool IsDead { get; }
        //RectangleShape InvaderRect { get; }
        //Vector2i InvaderPosition { get; }
        //Vector2f Velocity { get; }
        Vector2 InvaderPosition { get; }
        Vector2 Velocity { get; }

        public void Fire();

        public void TrackPlayerProjectile(ref List<Projectile> playerProjectiles);
    }
}

