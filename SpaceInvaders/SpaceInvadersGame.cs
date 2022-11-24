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
        public void run()
        {
            _window = new RenderWindow(new VideoMode(1920, 1080), "Space Invaders");
            _window.SetVisible(true);
            _window.Closed += new EventHandler(OnClosed);
            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear(Color.Black);                
                _window.Display();
            }
        }

        private static void OnClosed(Object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}