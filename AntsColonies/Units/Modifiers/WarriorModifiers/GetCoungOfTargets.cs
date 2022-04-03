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
    sealed class GetCountOfTargets : BaseModifier<Warrior, GetCountOfTargetsQuestion>
    {
        public GetCountOfTargets(Warrior unit) : base(unit) { }
        public override void HandleEvent(GetCountOfTargetsQuestion e)
        {
            if (e.Answerer == Unit)
                e.Answer = Unit.WarriorInfo.CountOfTargets;
        }
    }
}
