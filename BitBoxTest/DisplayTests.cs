using System;
using bitbox.SpaceInvadersCleanArchitecture.Logic;

namespace BitBoxTest
{
	public class DisplayTests
	{
		[Test]
		public void Close_Display_Test()
		{
            //Arrange
            var display = new Display();
			display.Init();

            //Act  
            display.Close();

            //Assert:
            Assert.That(display.GetIsClosed(), Is.EqualTo(false));
		}

	}
}

