using bitbox.SpaceInvadersCleanArchitecture.Menu.Entitys;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bitbox.SpaceInvadersCleanArchitecture.Logic;
using bitbox.SpaceInvadersCleanArchitecture.Menu.Logic;
using bitbox.SpaceInvadersCleanArchitecture.Menu.UseCases;
using SFML.Window;

namespace bitbox.SpaceInvadersCleanArchitecture.Menu.Logic
{
    public class MenuView : IMenuView
    {
        private int selectedItemIndex;
        private Font font;
        private IMenu menuWindow;
        const int MAX_NUMBER_OF_ITEMS = 3;
        private Text[] menu = new Text[MAX_NUMBER_OF_ITEMS];


        private IMenuController menuController = new MenuController();
        private IMenuInput menuInput = new MenuInput();


        private Clock clock;
        private Time elapsedTime;
        private Time delayTime;

        
        
        private static RenderWindow _window;
        // private static IMenu _menu;
        // private static readonly EventHandler<KeyEventArgs> onKeyPress;
        private static IMenuView menuView;
        private static IMenu menuEntity;
        
        //TODO ggf in mehrere Klassen trennen oder ShowMenu, ... zurück in Programm

        public MenuView()
        {
            menuWindow = new Menu.Entitys.Menu();
            menuController = new MenuController();
            menuInput = new MenuInput();

            font = new Font("./Fonts/Anonymice Powerline Bold Italic.ttf");

            // for (int x = 0; x < menuWindow.numberItems; x++)
            // {
            //     menu[x] = new Text(menuController.menuElements[x], font, 24);
            //     float textWidth = menu[x].GetLocalBounds().Width;
            //     menu[x].FillColor = Color.White;
            //     menu[x].Position = new Vector2f((menuWindow.width - textWidth) / 2, menuWindow.height / (menuWindow.numberItems + 1) * (x+1));
            // }

            menu[0] = new Text("Space Invaders", font, 24);
            // get width of the text
            float textWidth0 = menu[0].GetLocalBounds().Width;
            menu[0].FillColor = Color.Red;
            menu[0].Position = new Vector2f((menuWindow.width - textWidth0) / 2,
                menuWindow.height / (menuWindow.numberItems + 1) * 1);

            menu[1] = new Text("Tetris", font, 24);
            // get width of the text
            float textWidth1 = menu[1].GetLocalBounds().Width;
            menu[1].FillColor = Color.White;
            menu[1].Position = new Vector2f((menuWindow.width - textWidth1) / 2,
                menuWindow.height / (menuWindow.numberItems + 1) * 2);

            menu[2] = new Text("Exit", font, 24);
            // get width of the text
            float textWidth2 = menu[2].GetLocalBounds().Width;
            menu[2].FillColor = Color.White;
            menu[2].Position = new Vector2f((menuWindow.width - textWidth2) / 2,
                menuWindow.height / (menuWindow.numberItems + 1) * 3);


            // menu[0] = new Text("Space Invaders", font, 24);
            // // get width of the text
            // float textWidth0 = menu[0].GetLocalBounds().Width;
            // menu[0].FillColor = Color.Red;
            // menu[0].Position = new Vector2f((menuWindow.width - textWidth0) / 2, menuWindow.height / (MAX_NUMBER_OF_ITEMS + 1) * 1);
            //
            // menu[1] = new Text("Tetris", font, 24);
            // // get width of the text
            // float textWidth1 = menu[1].GetLocalBounds().Width;
            // menu[1].FillColor = Color.White;
            // menu[1].Position = new Vector2f((menuWindow.width - textWidth1) / 2, menuWindow.height / (MAX_NUMBER_OF_ITEMS + 1) * 2);
            //
            // menu[2] = new Text("Exit", font, 24);
            // // get width of the text
            // float textWidth2 = menu[2].GetLocalBounds().Width;
            // menu[2].FillColor = Color.White;
            // menu[2].Position = new Vector2f((menuWindow.width - textWidth2) / 2, menuWindow.height / (MAX_NUMBER_OF_ITEMS + 1) * 3);

            // selectedItemIndex = 0;
            
            clock = new Clock();
            elapsedTime = Time.Zero;
            delayTime = Time.FromSeconds(0.09f);
        }


        public void draw(RenderWindow window)
        {
            selectColorMenu();

            for (int i = 0; i < menuWindow.numberItems; i++)
            {
                window.Draw(menu[i]);
            }
        }

        public void selectColorMenu()
        {
            elapsedTime += clock.Restart();
            
            if (elapsedTime >= delayTime)
            {
                int selected = menuInput.GetMenuInput();
                int selectedIndex = menuController.moveMenuSelect(selected);
                    for (int j = 0; j < menuWindow.numberItems; j++)
                    {
                        if (j == selectedIndex)
                        {
                            menu[j].FillColor = Color.Red;
                        }
                        else
                        {
                            menu[j].FillColor = Color.White;
                        }
                    }
                if (selected == 10)
                {
                    switch(selectedIndex)
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
                            // Tetris tetris = new Tetris();
                            // tetris.Run();
                            return;
                        case 2:
                            _window.Close();
                            return;
                    }
                }
                elapsedTime = Time.Zero;
            }
        }
        
        
        public void showMenu()
        {
            menuView = new MenuView();
            menuEntity = new Entitys.Menu();
            // const int WINDOW_WIDTH = 640;
            // const int WINDOW_HEIGHT = 480;
            _window = new RenderWindow(new VideoMode(menuEntity.width, menuEntity.height), menuEntity.name);
            _window.SetVisible(true);
            //_menu = new Menu(WINDOW_WIDTH, WINDOW_HEIGHT);
            _window.Closed += new EventHandler(OnClosed);
            // _window.KeyPressed += new EventHandler<KeyEventArgs>(onKeyPressed);
            
            while (_window.IsOpen)
            {               
                _window.DispatchEvents();
                _window.Clear(Color.Black);
                menuView.draw(_window);
                _window.Display();
            }
        }
        
        
        private void OnClosed(Object sender, EventArgs e)
        {
            _window.Close();
        }


        
        
        
        

        // public void moveUp()
        // {
        //     if (selectedItemIndex - 1 >= 0)
        //     {
        //         menu[selectedItemIndex].FillColor = Color.White;
        //         selectedItemIndex--;
        //         menu[selectedItemIndex].FillColor = Color.Red;
        //     }
        // }
        //
        // public void moveDown()
        // {
        //     if (selectedItemIndex + 1 < MAX_NUMBER_OF_ITEMS)
        //     {
        //         menu[selectedItemIndex].FillColor = Color.White;
        //         selectedItemIndex++;
        //         menu[selectedItemIndex].FillColor = Color.Red;
        //     }
        // }

        // public int GetPressedItem()
        // {
        //     return selectedItemIndex;
        // }

        // public void hideMenu()
        // {
        //     _window.setVisible = false;
        // }
        //
        // public void showMenu()
        // {
        //     _window.setVisible = true;
        // }
    }
}