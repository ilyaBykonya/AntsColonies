using AntsColonies.Interfaces;

namespace AntsColonies.Locations
{
    sealed class GlobalMap : Location
    {
        public GlobalMap(IEventRouter router)
        : base(new(), router) => EventRouter.HandleEvent(new LocationFoundation<GlobalMap>(this));
    }
}
