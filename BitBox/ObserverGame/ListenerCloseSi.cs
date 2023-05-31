using bitbox.SpaceInvadersCleanArchitecture.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
