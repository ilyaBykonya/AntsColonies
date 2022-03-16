using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Base.Events.Notifications.MovementEvents.GoingEvents
{
    class UnitGoingToHeap : BaseMovementEvent
    {
        public UnitGoingToHeap(BaseHikingUnit unit) : base(unit) { }
    }
}
