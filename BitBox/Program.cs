using bitbox.Menu.Logic;

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
