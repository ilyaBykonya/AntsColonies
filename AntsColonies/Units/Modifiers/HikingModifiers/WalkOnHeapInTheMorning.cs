using AntsColonies.Interfaces;
using AntsColonies.Events;
using System.Linq;
using System;

namespace AntsColonies.Units
{
    class WalkOnHeapInTheMorning :
        BaseModifier<Hiking, MorningNotification>,
        IEventHandler<MorningNotification>
    {
        public WalkOnHeapInTheMorning(Hiking unit) : base(unit) { }
        public override void HandleEvent(MorningNotification e)
        {
            var no_empty_heaps = Unit.Simulation.Heaps.Where(heap => heap.Resources.Count != 0);
            Unit.Location = no_empty_heaps.ElementAt(new Random().Next(no_empty_heaps.Count()));
        }
    }
}
