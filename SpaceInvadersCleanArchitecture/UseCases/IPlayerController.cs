using SFML.Graphics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public interface IPlayerController
    {
        public RectangleShape PlayerRect { get; }
        //public void PlayerControls();
        public void PlayerMovement(int direktion);
        public void PlayerUpdate();
    }
}