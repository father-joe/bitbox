using bitbox.SpaceInvadersCleanArchitecture.Entitys;
using System.Numerics;
//using SFML.Graphics;
//using SFML.Window;
//using SFML.System;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class PlayerController : IPlayerController
    {
        private IPlayer player;
        private IGameWindow window;

        public Vector2 velocity = new Vector2(0, 0);
        //private RectangleShape _playerRect = new RectangleShape(new Vector2f(100, 50));

        private Vector2 _position = new Vector2();
        public Vector2 position { get { return _position; } }
        private Vector2 _size = new Vector2(120, 70);
        public Vector2 size { get { return _size; } }

        //private Time moveStep = new Time();
        //private Clock moveClock = new Clock();

        //public RectangleShape PlayerRect { get {return _playerRect;}}
        //public bool isDead = false;
        //public bool isFired = false;

        public PlayerController()
        {
            this.window = new Entitys.GameWindow();
            this.player = new Player(velocity);
            _position = new Vector2(_position.X + window.width/2 - _size.X/2, window.height - (int)(_size.Y*2));
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

        public void PlayerShoot(bool shoot)
        {
            if(shoot)
            {
                Console.WriteLine("peng peng");
            }
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
            //moveStep = moveClock.ElapsedTime;

            if (!(_position.X < 0 && velocity.X < 0) &&
                !((_position.X + _size.X) > window.width && velocity.X > 0)) //Window bounds
            {
                _position = new Vector2(_position.X + velocity.X, _position.Y + velocity.Y); //Sets the players position
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