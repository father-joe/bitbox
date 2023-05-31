namespace bitbox.SpaceInvadersCleanArchitecture.Logic;

public interface IGameCombined : IGameObserverSender, IGame
{
    //TODO: Liskov
}