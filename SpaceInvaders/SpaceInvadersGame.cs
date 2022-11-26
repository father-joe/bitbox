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
        public static Vector2i windowSize = new Vector2i(1920, 1080);

        SpaceInvadersPlayer player = new SpaceInvadersPlayer();

        public void run()
        {
            _window = new RenderWindow(new VideoMode((uint)windowSize.X, (uint)windowSize.Y), "Space Invaders");
            _window.SetVisible(true);
            _window.Closed += new EventHandler(OnClosed);
            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear(Color.Black);

                player.PlayerControls();
                DrawPlayer(ref player);

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
    }
}