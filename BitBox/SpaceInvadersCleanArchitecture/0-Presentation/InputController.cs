using SFML.Window;
using bitbox.SpaceInvadersCleanArchitecture.Application;
using SFML.System;

namespace bitbox.SpaceInvadersCleanArchitecture.Presentation
{
    public class InputController : IInputController
    {

        public InputController()
        {

        }

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

        public bool Fire()
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space)) // Fire
            {
                return true;
            }
            else 
            {
                return false;
            }
        }


    }
}