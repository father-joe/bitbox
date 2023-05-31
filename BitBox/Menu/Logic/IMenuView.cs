using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace bitbox.Menu.Logic
{
    public interface IMenuView
    {
        public void selectColorMenu();
        public void draw(RenderWindow window);
        
        public void showMenu();
        

    }
}

        
 
