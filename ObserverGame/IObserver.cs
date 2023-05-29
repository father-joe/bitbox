namespace bitbox.SpaceInvadersCleanArchitecture.Logic;

public interface IObserver
{
   
    void Open(IGame game);

    void Close(IGame game);
}