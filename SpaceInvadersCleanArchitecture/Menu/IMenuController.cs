using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitbox.SpaceInvadersCleanArchitecture.Menu.UseCases
{
    public interface IMenuController
    {
        string[] menuElements { get; set; }
        int currentIndex { get; set; }

        public int moveMenuSelect(int menuInput);
        
        


    }
}
