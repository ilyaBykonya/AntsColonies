using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AntsColonies.Units
{
    class GetDamageQuestion : AbstractQuestion<IEventHandler, int>
    {
        public GetDamageQuestion(IEventHandler answerer) : base(answerer) { }
    }
    sealed class GetDamage : BaseModifier<Unit, GetDamageQuestion>
    {
        public GetDamage(Unit unit) : base(unit) { }
        public override void HandleEvent(GetDamageQuestion e)
        {
            if (e.Answerer == Unit)
                e.Answer = Unit.UnitInfo.Damage;
        }
    }
}
