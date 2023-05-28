using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public interface IMovableObject
    {
        public Vector2 position { get; }
        public Vector2 size { get; }

        public bool isDead { get; }

        public void Update(int direction);

        public bool isFire { get; }
        public int GetAnimation();

        public void SetIsDead(bool isDead);

        public bool isPlayerProjectile { get; }
    }
}


