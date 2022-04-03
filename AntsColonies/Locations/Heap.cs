using System.Collections.Generic;
using AntsColonies.Interfaces;

namespace AntsColonies.Locations
{
    sealed class HeapFoundation : INotification
    {
        public Heap Location { get; }
        public HeapFoundation(Heap heap) => Location = heap;
    }
    class Heap: Location
    {
        public Heap(LinkedList<Resource> resources, IEventHandler router)
        : base(resources, router) => EventRouter.HandleEvent(new HeapFoundation(this));
    }
}
