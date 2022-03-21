using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies.Interfaces
{
    interface IVoter
    {
        public void Vote(IVoting voting); 
    }
}
