using System.Collections;
using System.Collections.Generic;
using AntsColonies.Interfaces;
using AntsColonies.Units;
using System.Linq;

namespace AntsColonies.Locations
{
    abstract class BaseLocation : IResourceStorage, IEventHandler
    {
        public HashSet<IEventHandler> Subhandlers { get; } = new();
        public HashSet<BaseHiking> Units { get; } = new();
        public BaseLocation(LinkedList<Resource> resources) => Resources = resources;

        private LinkedList<Resource> Resources { get; }
        public int CountOfResources => Resources.Count;
        public bool PutResource(Resource resource)
        {
            Resources.AddLast(resource);
            return true;
        }
        public Resource TakeResource(ResourceCode resource = (ResourceCode)15)
        {
            for (var node = Resources.First; node != null; node = node.Next)
            {
                if((node.Value.Type | resource) != 0)
                {
                    Resource result = node.Value;
                    Resources.Remove(node);
                    return result;
                }
            }

            return null;
        }

        public abstract void Notify(INotification notification);
        public abstract void Vote(IVoting voting);
    }
}
