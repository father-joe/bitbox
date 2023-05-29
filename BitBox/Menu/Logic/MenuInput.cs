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
            // Console.WriteLine("key up");
            return 1;
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) // move down
        {
            // Console.WriteLine("key down");
            return 2;
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.Enter)) // choose
        {
            // Console.WriteLine("enter");
            return 10;
        }
        else return 0;

    }
}