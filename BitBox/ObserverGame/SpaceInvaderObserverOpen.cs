namespace bitbox.SpaceInvadersCleanArchitecture.Logic;

public class SpaceInvadersObserverOpen:IObserver
{
    public void Update(IGameCombined game)
    {
        if (game.GameOpen == true)
        {
            Console.WriteLine("game opens");
        }
    }
}