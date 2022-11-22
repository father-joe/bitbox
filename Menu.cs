using SFML.Graphics;
using SFML.System;

namespace bitbox
{
    public class Menu
    {
        const int MAX_NUMBER_OF_ITEMS = 3;

        private int selectedItemIndex;
        private Font font;
        private Text[] menu = new Text[MAX_NUMBER_OF_ITEMS];

        public Menu(float width, float height)
        {
            font = new Font("Assets/Fonts/Anonymice Powerline Bold Italic.ttf");
            menu[0] = new Text("Button 1", new Font(font));
			menu[0].FillColor = Color.Red;			
			menu[0].Position = new Vector2f(width / 2, height / (MAX_NUMBER_OF_ITEMS + 1) * 1);            

            menu[1] = new Text("Button 2", new Font(font));
            menu[1].FillColor = Color.White;
            menu[1].Position = new Vector2f(width / 2, height / (MAX_NUMBER_OF_ITEMS + 1) * 2);

            menu[2] = new Text("Exit", new Font(font));
            menu[2].FillColor = Color.White;
            menu[2].Position = new Vector2f(width / 2, height / (MAX_NUMBER_OF_ITEMS + 1) * 3);

			selectedItemIndex = 0;
        }

        ~Menu() {}

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