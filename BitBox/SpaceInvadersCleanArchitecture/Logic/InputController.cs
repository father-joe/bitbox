using SFML.Window;
using bitbox.SpaceInvadersCleanArchitecture.UseCases;
using SFML.System;

namespace bitbox.SpaceInvadersCleanArchitecture.Logic
{
    public class InputController : IInputController
    {
        private IMovableObject playerController;
        private Time moveStep = new Time();
        private Clock moveClock = new Clock();

        public InputController()
        {
            this.playerController = new PlayerController();
        }

        public int GetPlayerInput()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) // Right
            {
                //Console.WriteLine("click D");
                //playerController.PlayerMoveRight();
                return 1;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A)) // Left
            {
                //Console.WriteLine("click A");
                // playerController.PlayerMoveLeft();
                return 2;
            }
            else // Stop
            {
                //Console.WriteLine("stop");
                // playerController.PlayerMoveStop();
                return 0;
            }

            /*if (moveStep.AsSeconds() > 0.3f)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Space)) // Fire
                {
                    // playerController.PlayerFire();
                    //isFired = true;
                }

                moveClock.Restart();
            }*/
            
            //Console.WriteLine("Input: " + playerController.PlayerRect.Position.X);
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