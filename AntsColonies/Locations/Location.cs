using System.Collections.Generic;
using AntsColonies.Interfaces;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Linq;
using System;

namespace AntsColonies.Locations
{
    sealed class LocationFoundation<LocationType> : INotification where LocationType: Location
    {
        public LocationType Location { get; }
        public LocationFoundation(LocationType location) => Location = location;
    }
    abstract class Location :
        ISimulationParticipant,
        IResourceStorage,
        IEventRouter,
        IEventHandler<UnitCameToLocation>,
        IEventHandler<UnitLeftLocation>,
        IEventHandler<NightNotification>
    {
        protected List<Unit> UnitsList = new();
        public IReadOnlyCollection<Unit> Units => UnitsList;

        protected StandardEventRouter Router { get; } = new();
        public IReadOnlyCollection<IEventHandler> Subhandlers => Router.Subhandlers;
        public void SubscribeSubhandler(IEventHandler handler) => Router.SubscribeSubhandler(handler);
        public void UnsubscribeSubhandler(IEventHandler handler) => Router.UnsubscribeSubhandler(handler);

        protected LinkedList<Resource> ResourcesList = new();
        public IReadOnlyCollection<Resource> Resources => ResourcesList;
        public List<KeyValuePair<ResourceCode, int>> RequiredResources => new() { new((ResourceCode)15, int.MaxValue) };
        public Resource TakeResource(ResourceCode resource = (ResourceCode)15)
        {
            for (var node = ResourcesList.First; node != null; node = node.Next)
            {
                if ((node.Value.Type & resource) != 0)
                {
                    Resource result = node.Value;
                    ResourcesList.Remove(node);
                    return result;
                }
            }

            return null;
        }
        public bool PutResource(Resource resource)
        {
            ResourcesList.AddLast(resource);
            return true;
        }

        public IEventRouter EventRouter { get; }
        public Location(LinkedList<Resource> resources, IEventRouter router)
        {
            EventRouter = router;
            ResourcesList = resources;
            EventRouter.HandleEvent(new LocationFoundation<Location>(this));
        }

        public virtual void HandleEvent(IEvent e)
        {
            if (e is UnitCameToLocation)
                HandleEvent(e as UnitCameToLocation);
            if (e is UnitLeftLocation)
                HandleEvent(e as UnitLeftLocation);
            if (e is NightNotification)
                HandleEvent(e as NightNotification);

            Router.HandleEvent(e);
        }
        public void HandleEvent(UnitCameToLocation e)
        {
            if (e.Target == this)
                UnitsList.Add(e.Unit);
        }
        public void HandleEvent(UnitLeftLocation e)
        {
            if (e.Target == this)
                UnitsList.Remove(e.Unit);
        }
        public void HandleEvent(NightNotification e)
        {
            var branches = Resources.Count(res => res.Type == ResourceCode.Branch);
            var stones = Resources.Count(res => res.Type == ResourceCode.Stone);
            var leafs = Resources.Count(res => res.Type == ResourceCode.Leaf);
            var dewdrops = Resources.Count(res => res.Type == ResourceCode.Dewdrop);
            Console.WriteLine($"[{GetType().Name}] => [{branches}, {stones}, {leafs}, {dewdrops}] : [{Units.Count}]");
        }
    }
}
