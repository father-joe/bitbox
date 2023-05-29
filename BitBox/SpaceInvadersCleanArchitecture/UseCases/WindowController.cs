using System;
using bitbox.SpaceInvadersCleanArchitecture.Entitys;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
	public class WindowController : IWindowController
	{
		private IGameWindow window;

		public WindowController()
		{
			window = new GameWindow();
		}

        public int GetWindowWidth()
		{
			return window.width;
		}

		public int GetWindowHight()
		{
			return window.height;
		}

    }
}

