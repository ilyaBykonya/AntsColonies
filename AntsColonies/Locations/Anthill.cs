using AntsColonies.Interfaces;

namespace AntsColonies.Locations
{
    sealed class AnthillFoundation : INotification
    {
        public Anthill Location { get; }
        public AnthillFoundation(Anthill anthill) => Location = anthill;
    }
    class Anthill : Location
    {
        public Anthill(IEventHandler router)
        : base(new(), router) => EventRouter.HandleEvent(new AnthillFoundation(this));
    }
}
