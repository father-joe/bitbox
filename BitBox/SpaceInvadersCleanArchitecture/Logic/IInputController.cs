using SFML.Window;

namespace bitbox.SpaceInvadersCleanArchitecture.Logic
{
    public interface IInputController
    {
        public int GetPlayerInput();
        public bool Fire();

    }
}