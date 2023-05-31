namespace bitbox.SpaceInvadersCleanArchitecture.Presentation
{
    public interface IGame
    {
        bool GameOpen { get; set; }

        public void run();
    }
}