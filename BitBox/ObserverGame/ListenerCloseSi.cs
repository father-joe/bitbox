using bitbox.SpaceInvadersCleanArchitecture.Presentation;

namespace bitbox.ObserverGame
{
    public class ListenerCloseSi:IObserverListener
    {
        public void Update(IGameCombined game)
        {
            if (game.GameOpen == false)
            {
                Console.WriteLine("game closes");
            }
        }
    }
}
