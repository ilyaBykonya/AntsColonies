using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;

namespace AntsColonies.Units
{
    class TakeResourcesFromHeapOnDay :
        BaseModifier<Unit, DayNotification>,
        IEventHandler<DayNotification>
    {
        private Heap Heap => Unit.Location as Heap;
        private WorkerBackpack Backpack { get; }
        public TakeResourcesFromHeapOnDay(Unit unit, WorkerBackpack backpack) : base(unit) => Backpack = backpack;
        public override void HandleEvent(DayNotification e)
        {
            if (Heap is not null)
                new MoveResourcesBetweenStorages(Heap, Backpack, Unit.EventRouter).Execute();
        }
    }
}
