using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AntsColonies.Units
{
    sealed class GetCountOfHitsQuestion : AbstractQuestion<IEventHandler, int>
    {
        public GetCountOfHitsQuestion(IEventHandler answerer) : base(answerer) { }
    }
    sealed class GetCountOfHits : BaseModifier<Warrior, GetCountOfHitsQuestion>
    {
        public GetCountOfHits(Warrior unit) : base(unit) { }
        public override void HandleEvent(GetCountOfHitsQuestion e)
        {
            if (e.Answerer == Unit)
                e.Answer = Unit.WarriorInfo.CountOfHits;
        }
    }
}
