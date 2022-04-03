using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AntsColonies.Interfaces
{
    class StandardEventRouter : IEventRouter
    {
        private HashSet<IEventHandler> SubhandlersList { get; } = new();
        public IReadOnlyCollection<IEventHandler> Subhandlers => SubhandlersList;

        public void SubscribeSubhandler(IEventHandler handler) => SubhandlersList.Add(handler);
        public void UnsubscribeSubhandler(IEventHandler handler) => SubhandlersList.Remove(handler);
        public void HandleEvent(IEvent e) => SubhandlersList.ToList().ForEach(handler => handler.HandleEvent(e));
    }
}
