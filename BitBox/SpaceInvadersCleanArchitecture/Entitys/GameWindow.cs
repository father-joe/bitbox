using System;
namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
	public class GameWindow : IGameWindow
	{
        public int height { get; }

        public int width { get; }

        public GameWindow()
        {
            height = 960;
            width = (int)((double)1080 / (double)1.2);
        }
    }
}

