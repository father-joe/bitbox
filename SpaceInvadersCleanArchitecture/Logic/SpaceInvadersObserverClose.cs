namespace bitbox.SpaceInvadersCleanArchitecture.Logic;

public class SpaceInvadersObserverClose:IObserver
{
    public void Update(IGame game)
    {
        if (game == null)
        {
            Console.WriteLine("SpaceInvaders wurde geschlossen!");
        }
    }
}