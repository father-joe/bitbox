namespace bitbox;

public interface IObserver
{
    void Open(Game game);

    void Close(Game game);
}