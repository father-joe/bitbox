using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public interface IMovableObject
    {
        public Vector2 position { get; }
        public Vector2 size { get; }

        public bool isDead { get; }

        public void Update(int direction);

        public void SetPosition(Vector2 position);

        public bool isFire { get; }
        public int GetAnimation();

        public void SetIsDead(bool isDead);

        public void SetIsPlayerProjectile(bool playerProjectile);

        public bool isPlayerProjectile { get; }
    }
}


