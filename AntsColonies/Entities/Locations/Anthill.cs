using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies
{
    class Anthill : IResourceStorage
    {
        public BaseAntQueen Queen { get; }
        public Anthill(BaseAntQueen queen) => Queen = queen;

        //========================================================
        private Resources AnthillResourceStorage = new(0, 0, 0, 0);

        public Resources CurrentResources => AnthillResourceStorage;
        public Resources MaxResources => new(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);

        public void PutResources(Resources resources)
        {
            AnthillResourceStorage = new(AnthillResourceStorage.branch + resources.branch,
                         AnthillResourceStorage.leaf + resources.leaf,
                         AnthillResourceStorage.stone + resources.stone,
                         AnthillResourceStorage.dewdrop + resources.dewdrop);
        }
        public void TakeResources(Resources resources)
        {
            throw new InvalidOperationException("Resources cannot be taken from an anthill");
        }
        public Resources TryTakeResources(Resources resources)
        {
            throw new InvalidOperationException("Resources cannot be taken from an anthill");
        }
        //========================================================
    }
}
