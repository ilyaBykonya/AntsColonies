using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Units.HikingUnits.Warriors;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.TaskEntities.Units.GreenAnts.Warriors
{
    class SimpleAnomalyWarrior: BaseWarrior
    {
        protected IEventHandler Handler { get; }
        public SimpleAnomalyWarrior(YoungAntQueen queen, IEventHandler handler)
        : base(queen, "Simple anomaly", 1, 0, 1) => Handler = handler;
    }
}
