using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
    public interface IPlayer
    {
        Vector2 Velocity { get; set; }
        Vector2 size { get; }
        bool isDead { get; set; }

        void Fire();
    }
}