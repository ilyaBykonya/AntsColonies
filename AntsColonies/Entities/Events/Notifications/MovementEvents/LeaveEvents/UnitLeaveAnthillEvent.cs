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
    class UnitLeaveAnthillEvent : BaseMovementEvent
    {
        public Anthill Target { get; }
        public UnitLeaveAnthillEvent(BaseHikingUnit unit, Anthill target) : base(unit) => Target = target;
    }
}
