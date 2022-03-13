using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies
{
    class SongCicada : IEventHandler
    {
        public void HandleEvent(IEvent e)
        {
            if (e is AttackEvent)
                e.Reject();
            else
                e.Accept();
        }
    }
}
