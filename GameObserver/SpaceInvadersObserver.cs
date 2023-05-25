namespace bitbox;

public class SpaceInvadersObserver : IObserver
{
    //public void Open(IGame game)
    //{
    //    //if (game.CurrentGame is SpaceInvadersGame)
    //    //{
    //        Console.WriteLine("SpaceInvaders wurde erstellt!");
    //    //}
    //}

    //public void Close(IGame game)
    //{
    //    //if (game.CurrentGame is SpaceInvadersGame)
    //    //{
    //    Console.WriteLine("SpaceInvaders wurde geschlossen!");
    //    //}
    //}

    public void Update(IGame game)
    {
        if (game != null)
        {
            Console.WriteLine("SpaceInvaders wurde erstellt!");
        }

        if (game == null) 
        {
            Console.WriteLine("SpaceInvaders wurde geschlossen!");
        }
    }
}