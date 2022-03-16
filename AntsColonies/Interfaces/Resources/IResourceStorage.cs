namespace AntsColonies.Base.Resources
{
    interface IResourceStorage
    {
        public Resource TakeCell(ResourceCode resource = (ResourceCode)0xF);
        public void PutResource(Resource resource);
    }
}
