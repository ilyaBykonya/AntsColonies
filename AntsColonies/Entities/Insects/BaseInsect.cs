using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies
{
    abstract class BaseInsect : IEventHandler
    {
        public int Health { get; protected set; }

        public BaseInsect(int health) => Health = health;
        public abstract void HandleEvent(IEvent e);
    }
}
