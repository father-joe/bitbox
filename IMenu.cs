using SFML.Graphics;

namespace bitbox
{
    public interface IMenu
    {
        void draw(RenderWindow window);
        int GetPressedItem();
        void moveDown();
        void moveUp();
    }
}