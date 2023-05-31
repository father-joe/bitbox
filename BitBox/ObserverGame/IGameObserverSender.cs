namespace bitbox.SpaceInvadersCleanArchitecture.Logic;

public interface IGameObserverSender
{
    void Attach(IObserverListener observer);
    void Detach(IObserverListener observer);
    void Notify();
}