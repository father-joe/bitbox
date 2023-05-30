namespace bitbox.SpaceInvadersCleanArchitecture.Logic;

public class SpaceInvadersObserver:IObserver
{
    public void Open(IGameCombined game)
    {
            Console.WriteLine("SpaceInvaders wurde erstellt!");
    }

    public void Close(IGameCombined game)
    {
        Console.WriteLine("SpaceInvaders wurde geschlossen!");
    }
    
}