using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AntsColonies.Units
{
    sealed class StartFightOnDay : BaseModifier<Hiking, DayNotification>
    {
        public StartFightOnDay(Hiking unit) : base(unit) { }
        public override void HandleEvent(DayNotification e)
        {
            if (Unit.Location is not Heap)
                return;

            var targets = new GetCountOfTargetsQuestion(Unit).AskQuestion();
            var enemy = new GetAttackTargetsQuestion(Unit).AskQuestion().ToList().GetEnumerator();
            for (int hitIndex = 0; hitIndex < targets && enemy.MoveNext(); ++hitIndex)
                if (new FightProcessAction(Unit.Location, Unit, enemy.Current, EventRouter).Execute() == false)
                    --hitIndex;
        }
    }
}
