namespace AntsColonies.Base.Resources
{
    enum ResourceCode
    {
        Branch = 0x1,
        Leaf = 0x2,
        Stone = 0x4,
        Dewdrop = 0x8
    }
    record Resource(ResourceCode Type);
    
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
