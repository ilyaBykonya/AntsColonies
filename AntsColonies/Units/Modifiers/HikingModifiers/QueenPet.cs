using AntsColonies.Interfaces;
using AntsColonies.Events;
using System.Linq;
using System;

namespace AntsColonies.Units
{
    class QueenPet :
        BaseModifier<Hiking, MorningNotification>,
        IEventHandler<MorningNotification>
    {
        public QueenPet(Hiking unit) : base(unit) { }
        public override void HandleEvent(MorningNotification e)
        {
            var no_empty_heaps = Unit.Simulation.Heaps.
                Where(heap => heap.Resources.Count != 0).
                Where(heap =>
                {
                    var hikings = heap.Units.Where(unit => unit is Hiking).Where(unit => unit is not Worker).Select(unit => unit as Hiking);
                    foreach (var unit in hikings)
                        if (new IsMyRelateQuestion(Unit.Queen, unit.Queen).AskQuestion() == false)
                            return false;

                    return true;
                });

            if(no_empty_heaps.Count() > 0)
                Unit.Location = no_empty_heaps.ElementAt(new Random().Next(no_empty_heaps.Count()));
        }
    }
}

