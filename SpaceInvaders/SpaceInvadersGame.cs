/***************************************************
**
** Logic for the Space Invaders Game
**
***************************************************/
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace bitbox
{
    class SpaceInvadersGame
    {
        private static RenderWindow _window;
        public static Vector2i windowSize = new Vector2i(1920 / 2, (int)((double)1080 / (double)1.2));

        SpaceInvadersPlayer player = new SpaceInvadersPlayer();
        SpaceInvadersInvader[,] invaders = new SpaceInvadersInvader[5, 11];

        public void run()
        {
            InitializeInvaders(ref invaders);

            _window = new RenderWindow(new VideoMode((uint)windowSize.X, (uint)windowSize.Y), "Space Invaders");
            _window.SetVisible(true);
            _window.Closed += new EventHandler(OnClosed);
            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear(Color.Black);

                player.PlayerControls();
                Loop(ref player, ref invaders);
                DrawPlayer(ref player);
                DrawInvaders(ref invaders);

                _window.Display();
            }
        }

        private static void OnClosed(Object sender, EventArgs e)
        {
            _window.Close();
        }

        private void DrawPlayer(ref SpaceInvadersPlayer player)
        {
            _window.Draw(player.playerRect);
        }

        private void DrawInvaders(ref SpaceInvadersInvader[,] invaders)
        {
            for (int i = 0; i < invaders.GetLength(0); i ++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    _window.Draw(invaders[i, j].invaderRect);                    
                }
            }
        }

        static void InitializeInvaders(ref SpaceInvadersInvader[,] invaders)
        {
            for(int i = 0; i < invaders.GetLength(0); i++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    invaders[i, j] = new SpaceInvadersInvader(new Vector2i(j, i), j, i); // j is row, i is column
                }
            }
        }

        static void Loop(ref SpaceInvadersPlayer player, ref SpaceInvadersInvader[,] invaders)
        {
            for (int i = 0; i < invaders.GetLength(0); i++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    if (invaders[i, j] != null) // checks if the element is already null
                    {
                        if (!invaders[i, j].isDead)
                        {
                            invaders[i, j].UpdateInvader();                                                                               
                        }
                        else
                        {
                            invaders[i, j] = null;
                        }
                    }
                }
            }
        }
    }
}