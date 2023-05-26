using bitbox.SpaceInvadersCleanArchitecture.Entitys;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitbox.SpaceInvadersCleanArchitecture.Logic
{
    public class ShowMenu
    {

        private int selectedItemIndex;
        private Font font;
        private IMenu menuWindow;

        public ShowMenu()
        {
            menuWindow = new Menu();

            private int MAX_NUMBER_OF_ITEMS = menuWindow.numberItems;
            private Text[] menu = new Text[MAX_NUMBER_OF_ITEMS];
            selectedItemIndex = CreateMenu(Menu, MAX_NUMBER_OF_ITEMS);
        }


        public int CreateMenu(Text[] menu, MAX_NUMBER_OF_ITEMS)
        {
            font = new Font("./Fonts/Anonymice Powerline Bold Italic.ttf");

            menu[0] = new Text("Space Invaders", font, 24);
            // get width of the text
            float textWidth0 = menu[0].GetLocalBounds().Width;
            menu[0].FillColor = Color.Red;
            menu[0].Position = new Vector2f((menuWindow.width - textWidth0) / 2, menuWindow.height / (MAX_NUMBER_OF_ITEMS + 1) * 1);

            menu[1] = new Text("Tetris", font, 24);
            // get width of the text
            float textWidth1 = menu[1].GetLocalBounds().Width;
            menu[1].FillColor = Color.White;
            menu[1].Position = new Vector2f((menuWindow.width - textWidth1) / 2, menuWindow.height / (MAX_NUMBER_OF_ITEMS + 1) * 2);

            menu[2] = new Text("Highscores", font, 24);
            // get width of the text
            float textWidth2 = menu[2].GetLocalBounds().Width;
            menu[2].FillColor = Color.White;
            menu[2].Position = new Vector2f((menuWindow.width - textWidth2) / 2, menuWindow.height / (MAX_NUMBER_OF_ITEMS + 1) * 3);

            menu[3] = new Text("Exit", font, 24);
            // get width of the text
            float textWidth3 = menu[3].GetLocalBounds().Width;
            menu[3].FillColor = Color.White;
            menu[3].Position = new Vector2f((menuWindow.width - textWidth3) / 2, menuWindow.height / (MAX_NUMBER_OF_ITEMS + 1) * 4);

            selectedItemIndex = 0;
            return selectedItemIndex;
        }


        public void draw(RenderWindow window)
        {
            for (int i = 0; i < MAX_NUMBER_OF_ITEMS; i++)
            {
                window.Draw(menu[i]);
            }
        }

        public void moveUp()
        {
            if (selectedItemIndex - 1 >= 0)
            {
                menu[selectedItemIndex].FillColor = Color.White;
                selectedItemIndex--;
                menu[selectedItemIndex].FillColor = Color.Red;
            }
        }

        public void moveDown()
        {
            if (selectedItemIndex + 1 < MAX_NUMBER_OF_ITEMS)
            {
                menu[selectedItemIndex].FillColor = Color.White;
                selectedItemIndex++;
                menu[selectedItemIndex].FillColor = Color.Red;
            }
        }

        public int GetPressedItem()
        {
            return selectedItemIndex;
        }

    }
}
