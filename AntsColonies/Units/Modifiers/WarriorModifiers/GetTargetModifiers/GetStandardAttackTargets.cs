using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AntsColonies.Units
{
    sealed class GetStandardAttackTargets : BaseModifier<Warrior, GetAttackTargetsQuestion>
    {
        public GetStandardAttackTargets(Warrior unit) : base(unit) { }
        public override void HandleEvent(GetAttackTargetsQuestion e)
        {
            if (e.Answerer == Unit)
                e.Answer = Unit.Location.Units.
                    Where(unit => unit is Hiking).
                    Select(unit => unit as Hiking).
                    Where((unit) => new IsMyRelateQuestion(unit.Queen, Unit.Queen).AskQuestion() == false);
        }
    }
}
