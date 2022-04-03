using AntsColonies.Interfaces;

namespace AntsColonies.Locations
{
    sealed class Anthill : Location
    {
        public Anthill(IEventRouter router)
        : base(new(), router) => EventRouter.HandleEvent(new LocationFoundation<Anthill>(this));
    }
}
