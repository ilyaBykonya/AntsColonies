using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;

namespace AntsColonies.Notifications
{
    class MovementNotification: INotification
    {
        public BaseHiking Unit { get; }
        public MovementNotification(BaseHiking unit) => Unit = unit;
    }

    class UnitCameToAnthill: MovementNotification
    {
        public Anthill Target { get; }
        public UnitCameToAnthill(BaseHiking unit, Anthill target) : base(unit) => Target = target;

        public override string ToString() => $"Unit came to anthill [{Unit.UnitId}]";
    }
    class UnitLeftAnthill : MovementNotification
    {
        public Anthill Target { get; }
        public UnitLeftAnthill(BaseHiking unit, Anthill target) : base(unit) => Target = target;

        public override string ToString() => $"Unit left anthill [{Unit.UnitId}]";
    }

    class UnitCameToHeap : MovementNotification
    {
        public Heap Target { get; }
        public UnitCameToHeap(BaseHiking unit, Heap target) : base(unit) => Target = target;

        public override string ToString() => $"Unit came to heap [{Unit.UnitId}]";
    }
    class UnitLeftHeap : MovementNotification
    {
        public Heap Target { get; }
        public UnitLeftHeap(BaseHiking unit, Heap target) : base(unit) => Target = target;

        public override string ToString() => $"Unit left heap [{Unit.UnitId}]";
    }
}
