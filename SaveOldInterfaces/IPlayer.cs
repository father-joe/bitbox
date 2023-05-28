using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys.alt
{
    public interface IPlayer
    {
        Vector2 Velocity { get; set; }
        Vector2 size { get; }
        bool isDead { get; set; }

        //void Fire();
    }
}