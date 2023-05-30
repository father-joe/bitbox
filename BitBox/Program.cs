
using SFML.Graphics;
using SFML.Window;
using bitbox.Menu.Entitys;
using bitbox.Menu.UseCases;
using bitbox.Menu.Logic;
using bitbox.SpaceInvadersCleanArchitecture.Logic;

namespace bitbox
{
    public static class Program
    {
        private static IMenuView menuView;

        public static void Main(String[] args)
        {
            

            menuView = new MenuView();         
            
            menuView.showMenu();
        }
    }
}
