using System;
using SFML.Graphics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
	public interface IProjectile
	{
        bool PlayerProjectile { get; }
        bool IsDead { get; }
        RectangleShape ProjectileRect { get; }

        void Update();
    }
}

