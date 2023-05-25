//namespace bitbox;

//public class Game
//{
//    private IGame currentGame;

//    // Property for getting and setting the current game
//    public IGame CurrentGame
//    {
//        get { return currentGame; }
//        set
//        {
//            currentGame = value;
//            Notify_open(); // Notify the observers that the game has changed
//            Notify_close();
//        }
//    }

//    // List of observers
//    private List<IObserver> observers = new List<IObserver>();

//    // Method for adding an observer
//    public void Attach(IObserver observer)
//    {
//        Console.WriteLine("Subject: Attached an observer.");
//        observers.Add(observer);
//    }

//    // Method for removing an observer
//    public void Detach(IObserver observer)
//    {
//        Console.WriteLine("Subject: Detached an observer.");
//        observers.Remove(observer);
//    }

//    // Method for notifying the observers
//    public void Notify_open()
//    {
//        Console.WriteLine("Subject: Notifying observers...");
//        foreach (IObserver observer in observers)
//        {
//            observer.Open(this);
//        }
//    }

//    // Method for notifying the observers
//    public void Notify_close()
//    {
//        Console.WriteLine("Subject: Notifying observers...");
//        foreach (IObserver observer in observers)
//        {
//            observer.Close(this);
//        }
//    }
//}