using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Base.Events.VotingEvents.ResourceEvents
{
    class TakeResourcesEvent: BaseVoting
    {
        public ResourcesHeap TargetHeap { get; }
        public BaseHikingUnit Collector { get; }

        public TakeResourcesEvent(ResourcesHeap heap, BaseHikingUnit collector)
        {
            Collector = collector;
            TargetHeap = heap;
        }
    }
}
