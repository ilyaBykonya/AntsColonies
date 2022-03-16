using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events.Notifications.MovementEvents.LeaveEvents;
using AntsColonies.Base.Events.Notifications.MovementEvents.CameEvents;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Base.Locations
{
    class ResourcesHeap : IResourceStorage, IEventHandler
    {
        public LinkedList<IEventHandler> SubhandlersList { get; } = new();
        protected LinkedList<ResourceCell> ResourceStorage { get; } = new();

        public ResourcesHeap(LinkedList<ResourceCell> startResources) => ResourceStorage = startResources;
        
        public bool HandleEvent(IEvent e)
        {
            if(e is UnitCameToHeapEvent)
            {
                var handledEvent = e as UnitCameToHeapEvent;
                if (handledEvent.Target == this)
                    SubhandlersList.AddLast(handledEvent.Unit);
            }
            else if(e is UnitLeaveHeapEvent)
            {
                var handledEvent = e as UnitLeaveHeapEvent;
                if (handledEvent.Target == this)
                    SubhandlersList.Remove(handledEvent.Unit);
            }

            foreach (var handler in SubhandlersList)
                if (handler.HandleEvent(e) == false)
                    return false;


            return true;
        }
        public void PutResource(Resource resource) => ResourceStorage.AddLast(new ResourceCell(resource));
        public Resource TakeCell(ResourceCode resource = (ResourceCode)15)
        {
            foreach (var cell in ResourceStorage)
            {
                if ((cell.ValidResources | resource) != 0 && cell.HasResource)
                {
                    ResourceStorage.Remove(cell);
                    return cell.TakeResource(); ;
                }
            }
            throw new InvalidOperationException("Cannot take " + resource + " from this anthill");
        }
    }
}
