using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
    public interface IPlayer
    {
        Vector2 Velocity { get; set; }
        bool isDead { get; set; }

        void Fire();



    }
}