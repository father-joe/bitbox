using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
    public interface IMenu
    {
        uint height { get; }
        uint width { get; }

        int numberItems { get; }

        string name { get; }
    }
}
