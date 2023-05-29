using SFML.Graphics;
using SFML.System;

namespace bitbox
{
    class Globals
    {
        private static Texture[] playertxr = new Texture[2];
        public static Vector2i windowSize = new Vector2i(1920 / 2, (int)((double)1080 / (double)1.2));

        public Globals()
        {
            playertxr[0] = new Texture("./Textures/invader1.png");
            playertxr[1] = new Texture("./Textures/invader2.png");
        }

        public static void InvaderTexture(ref RectangleShape rect, int index)
        {
            rect.Texture = playertxr[index];
        }
    }
}