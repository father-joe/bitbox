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


    //public void Open(IGameCombined game)
    //{
    //        Console.WriteLine("SpaceInvaders wurde erstellt!");
    //}

    //public void Close(IGameCombined game)
    //{
    //    Console.WriteLine("SpaceInvaders wurde geschlossen!");
    //}

    //TODO delete one part?

}