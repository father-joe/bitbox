namespace bitbox;

public interface IGame
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    //void Notify_open();
    //void Notify_close();
    void Notify();
}