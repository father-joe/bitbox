using SFML.Graphics;
using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public interface IPlayerController
    {
        public Vector2 position { get; }
        public Vector2 size { get; }
        public void PlayerMovement(int direction);
        public void PlayerShoot(bool shoot);
        public void PlayerUpdate();
    }
}