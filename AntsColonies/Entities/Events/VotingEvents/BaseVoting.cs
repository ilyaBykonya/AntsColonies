using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;


namespace AntsColonies.Base.Events.VotingEvents
{
    class BaseVoting: IEvent
    {
        public bool VotesResultValue = true;
        public bool HandleResult => VotesResultValue;

        public BaseVoting() { }
        public void Accept() { }
        public void Reject() { VotesResultValue = false; }
    }
}
