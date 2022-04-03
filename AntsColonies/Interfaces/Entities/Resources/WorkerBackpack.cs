using System.Collections.Generic;
using AntsColonies.Interfaces;
using System.Linq;
using System;

namespace AntsColonies.Interfaces
{
    class WorkerBackpack : IResourceStorage
    {
        class ResourceCell
        {
            public ResourceCode ValidResources { get; }
            public bool HasResource => Resource != null;
            public Resource Resource { get; protected set; } = null;

            public ResourceCell(Resource resource)
            {
                ValidResources = resource.Type;
                Resource = resource;
            }
            public ResourceCell(ResourceCode validResources) => ValidResources = validResources;
            public bool PutResource(Resource resource)
            {
                if (Resource != null || (ValidResources | resource.Type) == 0)
                    return false;

                Resource = resource;
                return true;
            }
            public Resource TakeResource()
            {
                Resource result = Resource;
                Resource = null;
                return result;
            }
        }

        private ResourceCell[] Cells { get; }
        public int CountOfResources => Cells.Count(cell => cell.HasResource);
        public IEnumerable<ResourceCode> Types => Cells.Select(cell => cell.ValidResources);
        public IReadOnlyCollection<Resource> Resources => Cells.Where(cell => cell.HasResource).Select(cell => cell.Resource).ToList();
        public List<KeyValuePair<ResourceCode, int>> RequiredResources 
        {
            get
            {
                List<KeyValuePair<ResourceCode, int>> required = new();
                foreach (var cell in Cells)
                    if (cell.HasResource == false)
                        required.Add(new(cell.ValidResources, 1));

                return required;
            }
        }

        public WorkerBackpack(params ResourceCode[] types)
        {
            Cells = new ResourceCell[types.Length];
            for (int index = 0; index < types.Length; ++index)
                Cells[index] = new ResourceCell(types[index]);
        }
        public bool PutResource(Resource resource)
        {
            foreach (var cell in Cells)
                if (cell.PutResource(resource))
                    return true;

            return false;
        }
        public Resource TakeResource(ResourceCode resource = (ResourceCode)15)
        {
            for (int index = 0; index < Cells.Length; ++index)
                if (Cells[index].HasResource && ((Cells[index].ValidResources | resource) != 0))
                    return Cells[index].TakeResource();

            return null;
        }
        public void HandleEvent(IEvent e) { }
    }
}
