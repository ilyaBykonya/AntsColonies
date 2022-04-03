using System.Collections.Generic;

namespace AntsColonies.Interfaces
{
    interface IEvent { }

    interface IEventHandler
    {
        void HandleEvent(IEvent e);
    }
    interface IEventHandler<EventType> : IEventHandler where EventType : IEvent
    {
        void HandleEvent(EventType e);
    }
    
    interface IEventRouter : IEventHandler
    {
        IReadOnlyCollection<IEventHandler> Subhandlers { get; }
        void SubscribeSubhandler(IEventHandler handler);
        void UnsubscribeSubhandler(IEventHandler handler);
    }
}
