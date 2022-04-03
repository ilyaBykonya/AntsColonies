using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using System.Linq;

namespace AntsColonies.Units
{
    class StealResourcesFromEnemy :
        BaseModifier<Worker, DayNotification>,
        IEventHandler<DayNotification>
    {
        private Anthill Anthill => Unit.Location as Anthill;
        public StealResourcesFromEnemy(Worker unit) : base(unit) { }
        public override void HandleEvent(DayNotification e)
        {
            if (Anthill is null)
                return;

            var backpacks = Anthill.Units.Where(unit => unit is Worker).Select(unit => (unit as Worker).Backpack);
            foreach(var backpack in backpacks)
            {
                if (Unit.Backpack.RequiredResources.Count == 0)
                    break;

                new MoveResourcesBetweenStorages(backpack, Unit.Backpack, EventRouter).Execute();
            }
        }
    }
}
