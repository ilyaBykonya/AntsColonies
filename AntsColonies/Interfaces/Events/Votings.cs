using System.Collections.Generic;

namespace AntsColonies.Interfaces
{
    interface IVoting : IEvent
    { 
        public HashSet<IEventHandler> Voters { get; }
        public void Reject();
        public bool Vote();
    }
}
