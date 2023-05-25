using SFML.Graphics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public interface IPlayerController
    {
        public RectangleShape PlayerRect { get; }
        //public void PlayerControls();
        public void PlayerMovement(int direction);
        // public void PlayerMoveRight();
        // public void PlayerMoveLeft();
        // public void PlayerMoveStop();
        // public void PlayerFire();
        public void PlayerUpdate();
    }
}