using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;

namespace AntsColonies.Units
{
    class PutResourcesToAnthillOnNight :
        BaseModifier<Worker, NightNotification>,
        IEventHandler<NightNotification>
    {
        private Anthill Anthill => Unit.Location as Anthill;
        public PutResourcesToAnthillOnNight(Worker unit) : base(unit) { }
        public override void HandleEvent(NightNotification e)
        {
            if (Anthill is not null)
                new MoveResourcesBetweenStorages(Unit.Backpack, Anthill, Unit.EventRouter).Execute();
        }
    }
}
