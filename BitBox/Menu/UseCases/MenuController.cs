using bitbox.Menu.Entitys;

namespace bitbox.Menu.UseCases
{
    public class MenuController:IMenuController
    {
        private readonly IMenu menu = new Entitys.Menu();

        public int currentIndex { get; set; }

        public string[] menuElements { get; set; }
        
        public MenuController()
        {
            menu = new Entitys.Menu();
            currentIndex = 0;
            menuElements = new string[menu.numberItems];
            menuElements[0] = "SpaceInvaders";
            menuElements[1] = "Tetris";
            menuElements[2] = "Exit";
        }

        public int moveMenuSelect(int menuInput)
        {
            switch (menuInput)
            {
                case 1: //move up
                    if (currentIndex - 1 >= 0)
                    {
                        currentIndex = currentIndex - 1;
                        Console.WriteLine("currentIndex: " + currentIndex); }
                    break;
                case 2: //move down
                    if (currentIndex + 1 <= menu.numberItems - 1)
                    {
                        currentIndex = currentIndex + 1;
                        Console.WriteLine("currentIndex: " + currentIndex);
                    }
                    break;
                case 10: //enter
                    break;
                default:
                    break;
            }
            return currentIndex;
        }
    }
}
