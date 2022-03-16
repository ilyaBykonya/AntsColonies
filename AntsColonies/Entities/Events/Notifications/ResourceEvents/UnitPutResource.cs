using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Base.Events.Notifications.ResourceEvents
{
    class UnitPutResource : BaseNotification
    {
        public List<ResourceCell> Resources { get; }
        public BaseHikingUnit Unit { get; }
        public UnitPutResource(List<ResourceCell> resources, BaseHikingUnit unit)
        {
            Resources = resources;
            Unit = unit;
        }
    }
}

