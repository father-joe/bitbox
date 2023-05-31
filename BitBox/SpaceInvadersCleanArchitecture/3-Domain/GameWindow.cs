namespace bitbox.SpaceInvadersCleanArchitecture.Domain
{
	public class GameWindow : IGameWindow
	{
        public int height { get; }

        public int width { get; }

        public GameWindow()
        {
            height = 960;
            width = (int)((double)1080 / 1.2);
        }
    }
}

