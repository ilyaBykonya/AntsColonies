using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Base.Events.Notifications.MovementEvents.LeaveEvents
{
    class UnitLeaveHeapEvent : BaseMovementEvent
    {
        public ResourcesHeap Target { get; }
        public UnitLeaveHeapEvent(BaseHikingUnit unit, ResourcesHeap target) : base(unit) => Target = target;
    }
}
