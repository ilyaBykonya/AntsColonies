using System.Collections.Generic;
using AntsColonies.Base.Resources;

namespace AntsColonies.Base.Locations
{
    class Anthill : IResourceStorage
    {
        //public BaseAntQueen Queen { get; }
        //public Anthill(BaseAntQueen queen) => Queen = queen;

        protected LinkedList<ResourceCell> ResourceStorage;
        public void PutResource(Resource resource) => ResourceStorage.AddLast(new ResourceCell(resource));
        public Resource TakeCell(ResourceCode resource = (ResourceCode)15)
        {
            foreach(var cell in ResourceStorage)
            {
                if((cell.ValidResources | resource) != 0 && cell.HasResource)
                {
                    ResourceStorage.Remove(cell);
                    return cell.TakeResource(); ;
                }
            }
            return null;
        }
        //========================================================
    }
}
