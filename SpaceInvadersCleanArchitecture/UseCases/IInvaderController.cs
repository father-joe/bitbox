using SFML.Graphics;
using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public interface IInvaderController
    {
        public Vector2 position { get; }
        public Vector2 size { get; }
        public bool isDead { get; }

        public bool isFire { get; }
        public int GetAnimation();
        public void Update();
        public void SetIsDead(bool isDead);
    }
}