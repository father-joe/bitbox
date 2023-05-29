namespace bitbox.SpaceInvadersCleanArchitecture.Logic;

public interface IObserver
{
   
    void Open(IGameCombined game);

    void Close(IGameCombined game);
}