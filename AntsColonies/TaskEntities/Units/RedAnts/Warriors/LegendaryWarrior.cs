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

namespace AntsColonies.TaskEntities.Units.RedAnts.Warriors
{
    class LegendaryWarrior : BaseWarrior
    {
        protected IEventHandler Handler { get; }
        public LegendaryWarrior(YoungAntQueen queen, IEventHandler handler)
        : base(queen, "Legendary", 10, 6, 6) => Handler = handler;
    }
}
