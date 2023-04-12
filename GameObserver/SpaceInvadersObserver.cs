namespace bitbox;

public class SpaceInvadersObserver : IObserver
{
    public void Open(Game game)
    {
        //if (game.CurrentGame is SpaceInvadersGame)
        //{
            Console.WriteLine("SpaceInvaders wurde erstellt!");
        //}
    }

    public void Close(Game game)
    {
        //if (game.CurrentGame is SpaceInvadersGame)
        //{
        Console.WriteLine("SpaceInvaders wurde geschlossen!");
        //}
    }
}