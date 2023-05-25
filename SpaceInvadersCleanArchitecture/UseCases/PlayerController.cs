using bitbox.SpaceInvadersCleanArchitecture.Entitys;
using System.Numerics;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class PlayerController : IPlayerController
    {
        private IPlayer player;

        public Vector2f velocity = new Vector2f(0, 0);
        private RectangleShape _playerRect = new RectangleShape(new Vector2f(100, 50));

        public RectangleShape PlayerRect { get {return _playerRect;}}
        //public bool isDead = false;
        //public bool isFired = false;

        private Time moveStep = new Time();
        private Clock moveClock = new Clock();

        //public List<Projectile> projectiles = new List<Projectile>();

        public PlayerController(Vector2 velocity)
        {
            player = new Player(velocity);
            PlayerRect.Position = new Vector2f(PlayerRect.Position.X + Globals.windowSize.X/2 - PlayerRect.Size.X/2, Globals.windowSize.Y - (int)(PlayerRect.Size.Y*1.5));
        }

        /*public void PlayerControls() // Player controls
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) // Right
            {
                PlayerMovement(1);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A)) // Left
            {
                PlayerMovement(2);
            }
            else // Stop
            {
                PlayerMovement(0);
            }

            if (moveStep.AsSeconds() > 0.3f)
            {
                /*if (Keyboard.IsKeyPressed(Keyboard.Key.Space)) // Fire
                {
                    Fire();
                    //isFired = true;
                }
                moveClock.Restart();*/

            //PlayerUpdate(); // Updates the player
        //}

        public void PlayerMovement(int direktion)
        {
            if(direktion == 1)
            {
                velocity.X = 3;
            }
            else if (direktion == 2)
            {
                velocity.X = -3;
            }
            else
            {
                velocity.X = 0;
            }
            PlayerUpdate();
        }

        public void PlayerUpdate()
        {
            moveStep = moveClock.ElapsedTime;

            if (!(_playerRect.Position.X < 0 && velocity.X < 0) &&
                !((_playerRect.Position.X + _playerRect.Size.X) > Globals.windowSize.X && velocity.X > 0)) //Window bounds
            {
                _playerRect.Position = new Vector2f(_playerRect.Position.X + velocity.X, _playerRect.Position.Y + velocity.Y); //Sets the players position
            }
            //if (isFired)
            {
                /*for (int i = 0; i < projectiles.Count; i++)
                {
                    if (!projectiles[i].isDead)
                    {
                        projectiles[i].Update(); // Call the method shoot which will update projectiles position;
                    }
                    else
                    {
                        projectiles.RemoveAt(i); // Removes the instance of the, out of window bounds, projectile
                        //isFired = false; // When the projectile gets destroyed isFired turns to false
                    }
                }*/
            }
        }
    }
}