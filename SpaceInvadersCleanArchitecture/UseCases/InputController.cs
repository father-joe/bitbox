using SFML.Window;
namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class InputController :IInputController
    {
        public InputController() {}
        public int GetPlayerInput()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) // Right
            {
                return 1;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A)) // Left
            {
                return 2;
            }
            else // Stop
            {
                return 0;
            }
        }
    }
}