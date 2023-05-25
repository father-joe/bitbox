﻿using System.Numerics;
namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
	public class Player : IPlayer
	{
		public Vector2 Velocity = new Vector2(0, 0);
		public bool isDead = false;

		public Player(Vector2 velocity)
		{
			Velocity = velocity;
			isDead = false;
		}

		public void Fire()
        {
            Console.WriteLine("Peng");
        }

		public void TrackInvaderProjectile(ref List<Projectile> invaderProjectile)
        {
            // Logik zur Verfolgung des Spielerprojektils
        }
	}
}
