using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using System;

namespace AntsColonies.Events
{
    abstract class MovementNotification: INotification
    {
        public Unit Unit { get; }
        public Location Target { get; }
        public MovementNotification(Unit unit, Location target)
        {
            Target = target;
            Unit = unit;
        }
    }

    sealed class UnitCameToLocation : MovementNotification
    {
        public UnitCameToLocation(Unit unit, Location target) : base(unit, target) { }
        public override string ToString() => $"[Unit [{Unit.Id}] came to location <{ Target.ToString() }>]";
    }
    sealed class UnitLeftLocation : MovementNotification
    {
        public UnitLeftLocation(Unit unit, Location target) : base(unit, target) { }
        public override string ToString() => $"[Unit [{Unit.Id}] left location <{ Target.ToString() }>]";
    }
}
