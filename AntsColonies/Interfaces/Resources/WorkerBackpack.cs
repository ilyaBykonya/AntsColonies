using System.Collections.Generic;
using AntsColonies.Interfaces;
using System.Linq;

namespace AntsColonies.Interfaces
{
    /*
     Вообще, неплохо бы добавить какой-нибудь супер-пупер-умный
     алгоритм взятия ресурсов из кучи, но решать задачу о рюкзаке
     мне точно лень, так что будет просто жадный алгоритм.
     */
    class WorkerBackpack : IResourceStorage
    {
        private ResourceCell[] Cells { get; }
        public int CountOfResources => Cells.Count(cell => cell.HasResource);
        public IEnumerable<ResourceCode> Types => Cells.Select(cell => cell.ValidResources);

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
        public void Vote(IVoting voting) { }
    }
}
