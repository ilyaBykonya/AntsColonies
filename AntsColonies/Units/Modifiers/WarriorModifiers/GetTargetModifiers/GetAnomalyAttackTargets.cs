using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AntsColonies.Units
{
    sealed class GetAnomalyAttackTargets : BaseModifier<Warrior, GetAttackTargetsQuestion>
    {
        public GetAnomalyAttackTargets(Warrior unit) : base(unit) { }
        public override void HandleEvent(GetAttackTargetsQuestion e)
        {
            if (e.Answerer == Unit)
                e.Answer = Unit.Location.Units.
                    Where(unit => unit is Hiking).
                    Select(unit => unit as Hiking).
                    Where((unit) => new IsMyRelateQuestion(unit.Queen, Unit.Queen).AskQuestion() == true && unit != Unit);
        }
    }
}
