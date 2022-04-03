using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AntsColonies.Units
{
    class GetCountOfTargetsQuestion : AbstractQuestion<IEventHandler, int>
    {
        public GetCountOfTargetsQuestion(IEventHandler answerer) : base(answerer) { }
    }
    sealed class GetCountOfTargets : BaseModifier<Unit, GetCountOfTargetsQuestion>
    {
        private int CountOfTargets { get; }
        public GetCountOfTargets(Unit unit, int targets) : base(unit) => CountOfTargets = targets;
        public override void HandleEvent(GetCountOfTargetsQuestion e)
        {
            if (e.Answerer == Unit)
                e.Answer = CountOfTargets;
        }
    }
}
