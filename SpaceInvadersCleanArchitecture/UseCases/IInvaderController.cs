using SFML.Graphics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public interface IInvaderController
    {
        public RectangleShape invaderRect { get; }
        public void Update();
    }
}