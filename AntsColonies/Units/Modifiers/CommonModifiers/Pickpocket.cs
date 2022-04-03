using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using System.Linq;

namespace AntsColonies.Units
{
    class Pickpocket :
        BaseModifier<Unit, DayNotification>,
        IEventHandler<DayNotification>
    {
        private Anthill Anthill => Unit.Location as Anthill;
        private WorkerBackpack Backpack { get; }
        public Pickpocket(Unit unit, WorkerBackpack backpack) : base(unit) => Backpack = backpack;
        public override void HandleEvent(DayNotification e)
        {
            if (Anthill is null)
                return;

            var backpacks = Anthill.Units.Where(unit => unit is Worker).Select(unit => (unit as Worker).Backpack);
            foreach(var backpack in backpacks)
            {
                if (Backpack.RequiredResources.Count == 0)
                    break;

                new MoveResourcesBetweenStorages(backpack, Backpack, EventRouter).Execute();
            }
        }
    }
}
