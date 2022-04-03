using System.Collections.Generic;

namespace AntsColonies.Interfaces
{
    interface IResourceStorage : IEventHandler
    {
        public IReadOnlyCollection<Resource> Resources { get; }
        public List<KeyValuePair<ResourceCode, int>> RequiredResources { get; }
        public Resource TakeResource(ResourceCode resource = (ResourceCode)0xF);
        public bool PutResource(Resource resource);
    }
}
