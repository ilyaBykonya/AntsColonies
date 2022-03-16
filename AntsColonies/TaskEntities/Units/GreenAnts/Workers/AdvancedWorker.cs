using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Units.HikingUnits.Workers;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.TaskEntities.Units.GreenAnts.Workers
{
    class AdvancedWorker : BaseWorker
    {
        public AdvancedWorker(YoungAntQueen queen, IEventHandler handler)
        : base(queen, "Advanced", 6, 2, new(ResourceCode.Dewdrop | ResourceCode.Stone, ResourceCode.Dewdrop | ResourceCode.Stone)) { }
    }
}
