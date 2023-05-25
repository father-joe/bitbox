using System.Numerics;
using bitbox.Interfaces;
using SFML.System;
using bitbox.SpaceInvadersCleanArchitecture.UseCases;

namespace bitbox.SpaceInvadersCleanArchitecture.Logic
{
    class TestGame : IGame
    {
        static bool gameOver = false;
        static int invaderCount = 0;

        public void run()
        {
            //Globals g = new Globals();// DO NOT USE
            //Barrier[] barriers = new Barrier[4]; // Th original had 4 barriers
            IBarrierController[] barriers = new BarrierController[4];
            InitializeBarriers(ref barriers);

            IInvaderController[,] invaders = new InvaderController[5, 11];

            //IInvader[,] invaders = new Invader[5, 11]; // The original had a grid of 5 x 11 invaders
            InitializeInvaders(ref invaders);

            //playerRect.Position.X + Globals.windowSize.X/2 - playerRect.Size.X/2, Globals.windowSize.Y - (int)(playerRect.Size.Y*1.5)

            Vector2 velocity = new Vector2(0, 0);
            IPlayerController player = new PlayerController(velocity);

            IInputController input = new InputController();

            Display display = Display.GetInstance();
            display.Init();
            while (display.IsOpen())
            {
                display.Clear(); // Clears the window from the previous display
                display.CheckForEvents(); // Checks for events such as closing the window

                //player.PlayerControls();
                player.PlayerMovement(input.GetPlayerInput());
                Loop(ref player, ref invaders, ref barriers);

                /*if (player.isDead || gameOver)
                {
                    display.Close();
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("YOU LOST!");
                    }
                }*/

                display.DrawPlayer(ref player); // Player rectangle being passed to draw
                display.DrawInvaders(ref invaders); // Invader rectangle being passed to draw
                display.DrawBarriers(ref barriers);
                display.Update(); // Draws on the window from the buffer
            }
        }

        private void InitializeInvaders(ref IInvaderController[,] invaders)
        {
            for (int i = 0; i < invaders.GetLength(0); i++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    invaders[i, j] = new InvaderController(new Vector2(j, i), new Vector2(3, 0), i , j); // j is row, i is column
                }
            }
        }
        private void InitializeBarriers(ref IBarrierController[] barriers)
        {
            for (int i = 0; i < barriers.Length; i++)
            {
                barriers[i] = new BarrierController(i);
            }
        }

        private void Loop(ref IPlayerController player, ref IInvaderController[,] invaders, ref IBarrierController[] barriers) // Loops through all the invaders and updates their position
        {
            for (int i = 0; i < invaders.GetLength(0); i++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    if (invaders[i, j] != null) // checks if the element is already null
                    {
                        
                        if (/*!invaders[i, j].isDead*/ 0 == 0)
                        {
                            invaders[i, j].Update();
                            
                            /*
                            invaders[i, j].TrackPlayerProjectile(ref player.projectiles); // tracks if the player hit invader
                            player.TrackInvaderProjectile(ref invaders[i, j].projectiles); // tracks if the invader hit the player

                            for (int p = 0; p < barriers.Length; p++)
                            {
                                barriers[p].TrackProjectile(ref invaders[i, j].projectiles);
                            }
                            */

                        }
                        else
                        {
                            //invaders[i, j] = null;
                        }
                        
                    }
                }
            }
            for (int i = 0; i < barriers.Length; i++)
            {
                //barriers[i].TrackProjectile(ref player.projectiles);
            }

            if (invaderCount == invaders.GetLength(0) * invaders.GetLength(1))
            {
                gameOver = true;
            }
        }
    }
}

