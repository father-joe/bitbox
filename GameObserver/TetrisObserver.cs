namespace bitbox;

public class TetrisObserver : IObserver
{
    public void Open(Game game)
    {
        //if (game.CurrentGame is Tetris)
        //{
            Console.WriteLine("Tetris wurde erstellt!");
        //}
    }

    public void Close(Game game)
    {
        //if (game.CurrentGame is Tetris)
        //{
        Console.WriteLine("Tetris wurde geschlossen!");
        //}
    }
}
    