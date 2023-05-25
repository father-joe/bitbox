namespace bitbox;

public class TetrisObserver : IObserver
{

    public void Update(IGame game)
    {
        if (game == null)
        {
            Console.WriteLine("Tetris wurde erstellt!");
        }

        if (game != null)
        {
            Console.WriteLine("Tetris wurde geschlossen!");
        }
    }



    //    public void Open(IGame game)
    //    {
    //        //if (game.CurrentGame is Tetris)
    //        //{
    //            Console.WriteLine("Tetris wurde erstellt!");
    //        //}
    //    }

    //    public void Close(IGame game)
    //    {
    //        //if (game.CurrentGame is Tetris)
    //        //{
    //        Console.WriteLine("Tetris wurde geschlossen!");
    //        //}
    //    }
}
