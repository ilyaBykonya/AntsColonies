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

namespace AntsColonies.TaskEntities.Units.RedAnts.Workers
{
    class EliteWorker : BaseWorker
    {
        public EliteWorker(YoungAntQueen queen, IEventHandler handler)
        :base(queen, "Elite", 8, 4, new(ResourceCode.Branch, ResourceCode.Branch)){}
    }
}
