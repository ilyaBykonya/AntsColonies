using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies.Base.Events.Notifications.MovementEvents.CameEvents
{
    class UnitCameToHeapEvent : BaseMovementEvent
    {
        public ResourcesHeap Target { get; }
        public UnitCameToHeapEvent(BaseHikingUnit unit, ResourcesHeap target) : base(unit) => Target = target;
    }
}
