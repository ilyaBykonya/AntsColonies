using System.Collections.Generic;

namespace AntsColonies.Interfaces
{
    interface IResourceStorage: IVoter
    {
        public int CountOfResources { get; }

        public Resource TakeResource(ResourceCode resource = (ResourceCode)0xF);
        public bool PutResource(Resource resource);
    }
}
