namespace bitbox.SpaceInvadersCleanArchitecture.Presentation;

public interface IGameObserver
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}