namespace AntsColonies.Interfaces
{
    interface IEvent { }
    interface IEventHandler
    {
        void HandleEvent(IEvent e);
    }
    interface IEventHandler<EventType>: IEventHandler where EventType: IEvent
    {
        void HandleEvent(EventType e);
    }
}
