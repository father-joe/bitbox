using SFML.Graphics;
using SFML.Window;

namespace bitbox
{
    class Program
    {
        private static RenderWindow _window;
        private static Menu _menu;
        private static readonly EventHandler<KeyEventArgs> onKeyPress;

        public static void Main(String[] args)
        {
            _window = new RenderWindow(new VideoMode(600, 600), "Test");
            _window.SetVisible(true);
            _menu = new Menu(600, 600);
            _window.Closed += new EventHandler(OnClosed);
            _window.KeyPressed += new EventHandler<KeyEventArgs>(onKeyPressed);
            while (_window.IsOpen)
            {               
                _window.DispatchEvents();
                _window.Clear(Color.Black);
                _menu.draw(_window);
                _window.Display();
            }
        }

        private static void onKeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            switch(e.Code)
            {
                case Keyboard.Key.Up:
                    _menu.moveUp();
                    break;
                case Keyboard.Key.Down:
                    _menu.moveDown();
                    break;
                case Keyboard.Key.Enter:
                    switch(_menu.GetPressedItem())
                    {
                        case 0:
                            Console.WriteLine("Button 1 has been pressed");                 
                            return;
                        case 1:
                            Console.WriteLine("Button 2 has been pressed");
                            Tetris tetris = new Tetris();
                            tetris.Run();
                            return;
                        case 2:
                            _window.Close();
                            return;
                    }
                    return;
            }            
        }

        private static void OnClosed(Object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}
