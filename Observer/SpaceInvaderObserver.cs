namespace bitbox.SpaceInvadersCleanArchitecture.Logic;

public class SpaceInvadersObserver:IObserver
{
    public void Open(IGame game)
    {
            Console.WriteLine("SpaceInvaders wurde erstellt!");
    }

    public void Close(IGame game)
    {
        Console.WriteLine("SpaceInvaders wurde geschlossen!");
    }
    
}