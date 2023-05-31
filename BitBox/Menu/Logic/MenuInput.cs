using SFML.System;
using SFML.Window;

namespace bitbox.Menu.Logic;

public class MenuInput:IMenuInput
{
    
    public MenuInput()
    {

    }
    
    public int GetMenuInput()
    {
        
        if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) // move up
        {
            return 1;
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) // move down
        {
            return 2;
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.Enter)) // choose
        {
            return 10;
        }
        else return 0;

    }
}