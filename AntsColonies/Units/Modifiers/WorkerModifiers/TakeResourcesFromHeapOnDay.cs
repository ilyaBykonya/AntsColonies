using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;

namespace AntsColonies.Units
{
    class TakeResourcesFromHeapOnDay :
        BaseModifier<Worker, DayNotification>,
        IEventHandler<DayNotification>
    {
        private Heap Heap => Unit.Location as Heap;
        public TakeResourcesFromHeapOnDay(Worker unit) : base(unit) { }
        public override void HandleEvent(DayNotification e)
        {
            if (Heap is not null)
                new MoveResourcesBetweenStorages(Heap, Unit.Backpack, Unit.EventRouter).Execute();
        }
    }
}
