using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Base.Events.VotingEvents.BattleEvents
{
    class BaseAttackEvent : BaseVoting
    {
        public ResourcesHeap TargetHeap { get; }
        public BaseHikingUnit Attacking { get; }
        public BaseHikingUnit Target { get; }

        public BaseAttackEvent(ResourcesHeap heap, BaseHikingUnit attacking, BaseHikingUnit target)
        {
            TargetHeap = heap;
            Attacking = attacking;
            Target = target;
        }
    }
}
