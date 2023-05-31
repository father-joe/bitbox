namespace bitbox.SpaceInvadersCleanArchitecture.Logic
{
    public interface IGame
    {
        bool GameOpen { get; set; }

        public void run();
    }
}