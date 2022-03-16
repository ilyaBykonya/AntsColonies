using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Base.Events.Notifications.LifeCycleEvents
{
    class UnitBirthEvent: BaseNotification
    {
        public BaseUnit Unit { get; }
        public UnitBirthEvent(BaseUnit unit) => Unit = unit;
        public override string ToString() => "Birth event";
    }
}

