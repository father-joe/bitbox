namespace bitbox;

public interface IGame
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}