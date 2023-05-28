namespace bitbox.SpaceInvadersCleanArchitecture.Logic;

public class SpaceInvadersObserverOpen:IObserver
{
    public void Update(IGame game)
    {
        if (game != null)
        {
            Console.WriteLine("SpaceInvaders wurde erstellt!");
        }
    }
}