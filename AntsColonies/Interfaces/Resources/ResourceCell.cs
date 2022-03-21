namespace AntsColonies.Interfaces
{
    class ResourceCell
    {
        public ResourceCode ValidResources { get; }
        public bool HasResource => Resource != null;
        protected Resource Resource = null;

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
}
