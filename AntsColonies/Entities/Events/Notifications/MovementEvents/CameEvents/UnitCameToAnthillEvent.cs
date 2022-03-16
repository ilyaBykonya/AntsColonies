using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies.Base.Events.Notifications.MovementEvents.CameEvents
{
    class UnitCameToAnthillEvent : BaseMovementEvent
    {
        public Anthill Target { get; }
        public UnitCameToAnthillEvent(BaseHikingUnit unit, Anthill target) : base(unit) => Target = target;
    }
}
