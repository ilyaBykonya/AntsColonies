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
    class EliteSkinnyWarrior : BaseWarrior
    {
        protected IEventHandler Handler { get; }
        public EliteSkinnyWarrior(YoungAntQueen queen, IEventHandler handler)
        : base(queen, "Elite skinny", 8, 4, 3) => Handler = handler;
    }
}
