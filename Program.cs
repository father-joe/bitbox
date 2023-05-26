using bitbox.SpaceInvadersCleanArchitecture.Entitys;
using SFML.Graphics;
using SFML.Window;

using bitbox.SpaceInvadersCleanArchitecture.UseCases;
using bitbox.SpaceInvadersCleanArchitecture.Logic;

namespace bitbox
{
    class Program
    {
        private static RenderWindow _window;
        // private static IShowMenu _menu;
        private static readonly EventHandler<KeyEventArgs> onKeyPress;
        private static IShowMenu showMenu;
        private static IMenu menu;

        public static void Main(String[] args)
        {
            showMenu = new ShowMenu();
            menu = new Menu();
            const int WINDOW_WIDTH = 640;
            const int WINDOW_HEIGHT = 480;
            _window = new RenderWindow(new VideoMode(640, 480), "Bitbox");
            _window.SetVisible(true);
            //_menu = new Menu(WINDOW_WIDTH, WINDOW_HEIGHT);
            _window.Closed += new EventHandler(OnClosed);
            _window.KeyPressed += new EventHandler<KeyEventArgs>(onKeyPressed);
            



            while (_window.IsOpen)
            {               
                
                _window.DispatchEvents();
                _window.Clear(Color.Black);
                showMenu.draw(_window);
                _window.Display();
            }
        }

        private static void onKeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            switch(e.Code)
            {
                case Keyboard.Key.Up:
                    showMenu.moveUp();
                    break;
                case Keyboard.Key.Down:
                    showMenu.moveDown();
                    break;
                case Keyboard.Key.Enter:
                    switch(showMenu.GetPressedItem())
                    {
                        case 0:
                            Console.WriteLine("Try to open Space Invaders");
                            //SpaceInvadersGame spaceInvaders = new SpaceInvadersGame();
                            //spaceInvaders.run();
                            IGame invaders = new TestGame();
                            _window.SetVisible(false);
                            invaders.run();
                            _window.SetVisible(true);
                            return;
                        case 1:
                            Console.WriteLine("Try to open Tetris");
                            Tetris tetris = new Tetris();
                            tetris.Run();
                            return;
                        case 2:                            
                            Console.WriteLine("Try to open Highscore");
                            //Highscores highscores = new Highscores();
                            //highscores.Show(_window);
                            return;
                        case 3:
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
