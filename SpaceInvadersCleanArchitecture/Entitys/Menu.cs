using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
    public class Menu:IMenu
    {
        public int height { get; }

        public int width { get; }

        public int numberItems { get; }

        public string name { get; }

        public Menu()
        {
            this.height = 640;
            this.width = 480;
            this.numberItems = 3;
            this.name = "bitbox";
        }
    }
}
