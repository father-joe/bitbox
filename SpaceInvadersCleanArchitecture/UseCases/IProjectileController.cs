using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public interface IProjectileController
    {
        public Vector2 position { get; }
        public Vector2 size { get; }
        public bool isPlayerProjectile {get;}
        public bool isDead { get; }

        public void Update();
        public void SetIsDead(bool isDead);
    }
}