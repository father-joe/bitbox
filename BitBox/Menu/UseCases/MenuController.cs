using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bitbox.Menu.Entitys;
using SFML.Window;

namespace bitbox.Menu.UseCases
{
    public class MenuController:IMenuController
    {
        private IMenu menu = new Entitys.Menu();

        public int currentIndex { get; set; }

        public string[] menuElements { get; set; }
        
        public MenuController()
        {
            menu = new Entitys.Menu();
            currentIndex = 0;
            // menuElements= {"SpaceInvaders", "Tetris", "Exit"};
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

                // if(menuInput == 1)//up
                // {
                //     if (currentIndex - 1 >= 0)
                //     {
                //         currentIndex = currentIndex - 1;
                //         Console.WriteLine("currentIndex: " + currentIndex); 
                //     }
                // }
                // else if (menuInput == 2)//down
                // {
                //     if (currentIndex + 1 <= menu.numberItems - 1)
                //     {
                //         currentIndex = currentIndex + 1;
                //         Console.WriteLine("currentIndex: " + currentIndex);
                //     }
                // }
                // else if (menuInput == 10)
                // {
                //     
                // }
                // else
                // {
                //     
                // }
                //
                // return currentIndex;
        }
            
        




        // public void MenuSelect(int selection)
        // {
        //     if(selection == 1)//up
        //     {
        //          
        //     }
        //     else if (selection == 2)//down
        //     {
        //         
        //     }
        //     else if (selection == 10)
        //     {
        //         
        //     }
        //     else
        //     {
        //         
        //     }
        // }
    }
}
