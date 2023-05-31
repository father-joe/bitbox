using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Application
{
    public interface IBarrierController
    {
        public Vector2 position { get; }
        public Vector2 size { get; }

        public void SetPosition(Vector2 position);
    }
}