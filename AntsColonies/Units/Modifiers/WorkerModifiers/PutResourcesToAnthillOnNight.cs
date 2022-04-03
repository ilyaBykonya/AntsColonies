using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;

namespace AntsColonies.Units
{
    class PutResourcesToAnthillOnNight :
        BaseModifier<Unit, NightNotification>,
        IEventHandler<NightNotification>
    {
        private Anthill Anthill => Unit.Location as Anthill;
        private WorkerBackpack Backpack { get; }
        public PutResourcesToAnthillOnNight(Unit unit, WorkerBackpack backpack) : base(unit) => Backpack = backpack;
        public override void HandleEvent(NightNotification e)
        {
            if (Anthill is not null)
                new MoveResourcesBetweenStorages(Backpack, Anthill, Unit.EventRouter).Execute();
        }
    }
}
