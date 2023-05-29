using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
    public interface IGameObject
    {
        bool isDead { get; }
        Vector2 Position { get; }
        Vector2 Velocity { get; }
        Vector2 size { get; }
    
        public bool GetIsDead();

        public void SetIsDead(bool isDead);

        public void ChangeDirektion();
    
        bool PlayerProjectile { get; }

        public void SetPlayerProjectile(bool isPlayerProjectile);


        public int Number { get; }
    }   
}