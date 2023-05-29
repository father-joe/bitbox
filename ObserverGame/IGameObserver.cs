namespace bitbox.SpaceInvadersCleanArchitecture.Logic;

public interface IGameObserver
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);

    void NotifyOpen();
    void NotifyClose();
}