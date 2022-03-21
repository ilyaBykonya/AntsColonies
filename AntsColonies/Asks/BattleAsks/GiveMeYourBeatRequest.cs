using System.Collections.Generic;
using AntsColonies.Notifications;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Actions;
using AntsColonies.Units;
using System;

namespace AntsColonies.Asks
{
    class GiveMeYourBeatRequest : BaseAsk
    {
        public BaseLocation Location{ get; }
        public BaseHiking Target { get; }
        public BaseAttack Hit { get; set; } = null;

        public GiveMeYourBeatRequest(BaseLocation location, BaseHiking target)
        : base(target)
        {
            Location = location;
            Target = target;
        }
        public override void ExecuteVoting()
        {
            VotingResultValue = true;
            base.ExecuteVoting();
        }
    }
}
