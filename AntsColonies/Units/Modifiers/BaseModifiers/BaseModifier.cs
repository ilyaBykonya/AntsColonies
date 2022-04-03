using AntsColonies.Interfaces;
using System;

namespace AntsColonies.Units
{
    abstract class BaseModifier<UnitType, EventType> :
        ISimulationParticipant, IModifier,
        IEventHandler<EventType>
        where UnitType : Unit
        where EventType : class, IEvent
    {
        public IEventHandler EventRouter => Unit.EventRouter;
        public Guid EventGuid => typeof(EventType).GUID;
        public UnitType Unit { get; }

        protected BaseModifier(UnitType unit) => Unit = unit;
        public void HandleEvent(IEvent e)
        {
            if (e is EventType)
                HandleEvent(e as EventType);
        }
        public abstract void HandleEvent(EventType e);
    }
}
