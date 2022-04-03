using AntsColonies.Interfaces;
using AntsColonies.Events;
using System;


namespace AntsColonies.Units
{
    class Sprinter : ISimulationParticipant, IModifier
    {
        public Sprinter(Unit unit) { }

        public Guid EventGuid => typeof(Sprinter).GUID;

        public IEventHandler EventRouter => throw new NotImplementedException();

        public void HandleEvent(FightProcessAction e)
        {
            throw new NotImplementedException();
        }

        public void HandleEvent(IEvent e)
        {
            throw new NotImplementedException();
        }
    }
}
