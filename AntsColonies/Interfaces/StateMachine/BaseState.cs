using AntsColonies.Base.Events;

namespace AntsColonies.Base.States
{
    abstract class BaseState : IEventHandler
    {
        public IEventHandler EventHandler { get; }

        public BaseState(IEventHandler handler) => EventHandler = handler;
        public abstract bool HandleEvent(IEvent e);
    }
}
