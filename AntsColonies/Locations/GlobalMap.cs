using AntsColonies.Interfaces;

namespace AntsColonies.Locations
{
    sealed class GlobalMapFoundation : INotification
    {
        public GlobalMap Location { get; }
        public GlobalMapFoundation(GlobalMap map) => Location = map;
    }
    class GlobalMap : Location
    {
        public GlobalMap(IEventHandler router)
        : base(new(), router) => EventRouter.HandleEvent(new GlobalMapFoundation(this));
    }
}
