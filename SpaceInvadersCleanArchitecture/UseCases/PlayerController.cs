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
        private IWindow window;

        public Vector2 velocity = new Vector2(0, 0);
        private RectangleShape _playerRect = new RectangleShape(new Vector2f(100, 50));

        private Time moveStep = new Time();
        private Clock moveClock = new Clock();

        public RectangleShape PlayerRect { get {return _playerRect;}}
        //public bool isDead = false;
        //public bool isFired = false;

        //public List<Projectile> projectiles = new List<Projectile>();

        public PlayerController()
        {
            this.window = new Entitys.Window();
            this.player = new Player(velocity);
            PlayerRect.Position = new Vector2f(PlayerRect.Position.X + window.width/2 - PlayerRect.Size.X/2, window.height - (int)(PlayerRect.Size.Y*5));
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

        public void PlayerMovement(int direction)
        {
            if(direction == 1)
            {
                velocity.X = 3;
            }
            else if (direction == 2)
            {
                velocity.X = -3;
            }
            else
            {
                velocity.X = 0;
            }
            PlayerUpdate();
        }

        // public void PlayerMoveRight()
        // {
        //     velocity.X = 3;
        //     PlayerUpdate();
        // }
        //
        // public void PlayerMoveLeft()
        // {
        //     velocity.X = -3;
        //     PlayerUpdate();
        // }
        // public void PlayerMoveStop()
        // {
        //     velocity.X = 0;
        //     PlayerUpdate();
        // }
        // public void PlayerFire()
        // {
        //     player.Fire();
        //     //PlayerUpdate();
        // }

        public void PlayerUpdate()
        {
            moveStep = moveClock.ElapsedTime;

            if (!(_playerRect.Position.X < 0 && velocity.X < 0) &&
                !((_playerRect.Position.X + _playerRect.Size.X) > window.width && velocity.X > 0)) //Window bounds
            {
                _playerRect.Position = new Vector2f(_playerRect.Position.X + velocity.X, _playerRect.Position.Y + velocity.Y); //Sets the players position
                //Console.WriteLine("Position: " + _playerRect.Position);
            }
            //if (isFired)
            //{
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
            //}
        }
    }
}