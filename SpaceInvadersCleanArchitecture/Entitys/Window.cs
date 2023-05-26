namespace bitbox.SpaceInvadersCleanArchitecture.Entitys;

public class Window:IWindow
{
    public int height { get; }

    public int width { get; }

    public Window()
    {
        this.height = 1920 / 2;
        this.width = (int)((double)1080 / (double)1.2);
    }
    
}