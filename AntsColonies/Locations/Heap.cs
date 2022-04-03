using System.Collections.Generic;
using AntsColonies.Interfaces;

namespace AntsColonies.Locations
{
    sealed class Heap: Location
    {
        public Heap(LinkedList<Resource> resources, IEventRouter router)
        : base(resources, router) => EventRouter.HandleEvent(new LocationFoundation<Heap>(this));
    }
}
