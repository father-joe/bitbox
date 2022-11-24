/***************************************************
**
** Class for showing the Space Invaders Game
**
***************************************************/
using SFML.Graphics;
using SFML.Window;

namespace bitbox
{
    class SpaceInvadersDisplay
    {
        private RenderWindow _window;
        
        public void Init()
        {
            _window = new RenderWindow(new VideoMode(1920, 1080), "Space Invaders");
            _window.SetFramerateLimit(60);
            _window.SetVisible(true);
            _window.Closed += new EventHandler(Close);
        }

        public void Close(Object sender, EventArgs e)
        {
            _window.Close();
        }

        public void Clear()
        {
            _window.Clear();
        }

        public void Update()
        {
            _window.Display();
        }

        public bool IsOpen()
        {
            return _window.IsOpen;
        }
    }
}