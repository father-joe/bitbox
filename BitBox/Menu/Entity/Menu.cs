﻿namespace bitbox.Menu.Entitys
{
    public class Menu:IMenu
    {
        public uint height { get; }

        public uint width { get; }

        public int numberItems { get; }

        public string name { get; }

        public Menu()
        {
            this.height = 480;
            this.width = 640;
            this.numberItems = 3;
            this.name = "Bitbox";
        }
    }
}
