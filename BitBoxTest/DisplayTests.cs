using System;
using bitbox.SpaceInvadersCleanArchitecture.Logic;

namespace BitboxTests
{
	public class DisplayTests
	{
		[Test]
		public void Close_Display_Test()
		{
			var display = new Display();
			display.Init();

			display.Close();

			Assert.That(display.GetIsClosed(), Is.EqualTo(false));
		}

	}
}

