namespace bitbox.SpaceInvadersCleanArchitecture.Logic;

public class ListenerOpenSi:IObserverListener
{
    public void Update(IGameCombined game)
    {
        if (game.GameOpen == true)
        {
            Console.WriteLine("game opens");
        }
    }
}