
using SFML.Graphics;
using SFML.Window;
using bitbox.SpaceInvadersCleanArchitecture.Menu.Entitys;
using bitbox.SpaceInvadersCleanArchitecture.Menu.UseCases;
using bitbox.SpaceInvadersCleanArchitecture.Menu.Logic;
using bitbox.SpaceInvadersCleanArchitecture.Logic;

namespace bitbox
{
    class Program
    {
        // private static RenderWindow _window;
        // private static IMenu _menu;
        // private static readonly EventHandler<KeyEventArgs> onKeyPress;
        private static IMenuView menuView;
        // private static IMenu menu;

        public static void Main(String[] args)
        {
            

            menuView = new MenuView();
            // menu = new Menu();
            // // const int WINDOW_WIDTH = 640;
            // // const int WINDOW_HEIGHT = 480;
            // _window = new RenderWindow(new VideoMode(menu.width, menu.height), menu.name);
            // _window.SetVisible(true);
            // //_menu = new Menu(WINDOW_WIDTH, WINDOW_HEIGHT);
            // _window.Closed += new EventHandler(OnClosed);
            // // _window.KeyPressed += new EventHandler<KeyEventArgs>(onKeyPressed);
            //
            // while (_window.IsOpen)
            // {               
            //     _window.DispatchEvents();
            //     _window.Clear(Color.Black);
            //     menuView.draw(_window);
            //     _window.Display();
            // }
            
            
            menuView.showMenu();
        }

        // private static void onKeyPressed(object sender, SFML.Window.KeyEventArgs e)
        // {
        //     switch(e.Code)
        //     {
        //         case Keyboard.Key.Up:
        //             menuView.moveUp();
        //             break;
        //         case Keyboard.Key.Down:
        //             menuView.moveDown();
        //             break;
        //         case Keyboard.Key.Enter:
        //             switch(menuView.GetPressedItem())
        //             {
        //                 case 0:
        //                     Console.WriteLine("Try to open Space Invaders");
        //                     //SpaceInvadersGame spaceInvaders = new SpaceInvadersGame();
        //                     //spaceInvaders.run();
        //                     IGame invaders = new TestGame();
        //                     _window.SetVisible(false);
        //                     invaders.run();
        //                     _window.SetVisible(true);
        //                     return;
        //                 case 1:
        //                     Console.WriteLine("Try to open Tetris");
        //                     Tetris tetris = new Tetris();
        //                     tetris.Run();
        //                     return;
        //                 case 2:
        //                     _window.Close();
        //                     return;
        //             }
        //             return;
        //     }            
        // }

        // private static void OnClosed(Object sender, EventArgs e)
        // {
        //     _window.Close();
        // }

    }
}
