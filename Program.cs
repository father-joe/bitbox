using SFML.Graphics;
using SFML.Window;

namespace bitbox
{
    class Program
    {
        private static RenderWindow _window;

        public static void Main(String[] args)
        {
            _window = new RenderWindow(new VideoMode(800, 600), "SFML window");
            _window.SetVisible(true);
            _window.Closed += new EventHandler(OnClosed);
            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear(Color.Red);
                _window.Display();
             }
        }

        private static void OnClosed(Object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}
