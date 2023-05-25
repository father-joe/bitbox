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
            const int WINDOW_WIDTH = 640;
            const int WINDOW_HEIGHT = 480;
            _window = new RenderWindow(new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), "Bitbox");
            _window.SetVisible(true);
            _menu = new Menu(WINDOW_WIDTH, WINDOW_HEIGHT);
            _window.Closed += new EventHandler(OnClosed);
            _window.KeyPressed += new EventHandler<KeyEventArgs>(onKeyPressed);

            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                    _window.Close();
                _window.Clear(Color.Black);
                _menu.draw(_window);
                _window.Display();
            }

        }

        private static void onKeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            //Game game = new Game();
            
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
                            //Console.WriteLine("Try to open Space Invaders");
                            IObserver spaceInvadersObserver = new SpaceInvadersObserver();
                            SpaceInvadersGame spaceInvaders = new SpaceInvadersGame();
                            spaceInvaders.Attach(spaceInvadersObserver);
                            //game.Notify_open();
                            //game.Detach(spaceInvadersObserver);
                            spaceInvaders.run();
                            //game.Attach(spaceInvadersObserver);
                            //spaceInvaders = null;
                            //game.Notify_close();
                            spaceInvaders.Detach(spaceInvadersObserver);
                            return;
                        case 1:
                            //Console.WriteLine("Try to open Tetris");
                            IObserver tetrisObserver = new TetrisObserver();
                            Tetris tetris = new Tetris();

                            //tetris.Attach(tetrisObserver);

                            //game.Notify_open();
                            //game.Detach(tetrisObserver);
                            tetris.Run();
                            //game.Attach(tetrisObserver);
                            //tetris = null;
                            //game.Notify_close();

                            //tetris.Detach(tetrisObserver);

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
