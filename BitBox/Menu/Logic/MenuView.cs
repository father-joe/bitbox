using bitbox.Menu.Domain;
using SFML.Graphics;
using SFML.System;
using bitbox.SpaceInvadersCleanArchitecture.Presentation;
using bitbox.Menu.UseCases;
using SFML.Window;
using bitbox.ObserverGame;

namespace bitbox.Menu.Logic
{
    public class MenuView : IMenuView
    {
        private readonly Font font = new Font("./Fonts/Anonymice Powerline Bold Italic.ttf");
        private readonly IMenu menuWindow;
        const int MAX_NUMBER_OF_ITEMS = 3;
        private readonly Text[] menu = new Text[MAX_NUMBER_OF_ITEMS];


        private readonly IMenuController menuController;
        private readonly IMenuInput menuInput;


        private readonly Clock clock;
        private Time elapsedTime;
        private Time delayTime;
       
        
        private static RenderWindow _window;
        private static IMenuView menuView;
        
        public MenuView()
        {
            menuWindow = new Menu.Domain.Menu();
            menuController = new MenuController();
            menuInput = new MenuInput();


            for (int x = 0; x < menuWindow.numberItems; x++)
            {
                menu[x] = new Text(menuController.menuElements[x], font, 24);
                float textWidth = menu[x].GetLocalBounds().Width;
                menu[x].FillColor = Color.White;
                menu[x].Position = new Vector2f((menuWindow.width - textWidth) / 2, 
                    menuWindow.height / (menuWindow.numberItems + 1) * (x+1));
            }

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
                            IGameCombined invaders = new Game();
                            IObserverListener siOpen = new ListenerOpenSi();
                            IObserverListener siClose = new ListenerCloseSi();
                            invaders.Attach(siOpen);
                            invaders.Attach(siClose);
                            invaders.GameOpen = true;
                            invaders.Notify();
                            _window.SetVisible(false);
                            invaders.run();
                            _window.SetVisible(true);
                            invaders.GameOpen = false;
                            invaders.Notify();
                            invaders.Detach(siOpen);
                            invaders.Detach(siClose);
                            return;
                        case 1:
                            Console.WriteLine("Try to open Tetris");
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
            _window = new RenderWindow(new VideoMode(menuWindow.width, menuWindow.height), menuWindow.name);
            _window.SetVisible(true);
            _window.Closed += new EventHandler(OnClosed);
            
            while (_window.IsOpen)
            {               
                _window.DispatchEvents();
                _window.Clear(Color.Black);
                menuView.draw(_window);    //null Exeption
                _window.Display();
            }
        }
        
        
        private void OnClosed(Object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}