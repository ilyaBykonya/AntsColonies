using System;

namespace AntsColonies
{
    class BaseAntWorker: BaseHiking, IResourceStorage
    {
        public BaseAntWorker(int health, int armor, Resources backpack) : base(health, armor)
        {
            MaxResources = backpack;
        }
        public override void HandleEvent(IEvent e)
        {
            throw new NotImplementedException();
        }


        //========================================================
        private Resources CurrentResourcesValue = new(0, 0, 0, 0);
        public Resources CurrentResources => CurrentResourcesValue;
        public Resources MaxResources { get; }

        public void PutResources(Resources resources)
        {
            if (CurrentResources.branch + resources.branch > MaxResources.branch)
                throw new ArgumentOutOfRangeException("Not enought place in heap");
            if (CurrentResources.leaf + resources.leaf > MaxResources.leaf)
                throw new ArgumentOutOfRangeException("Not enought place in heap");
            if (CurrentResources.stone + resources.stone > MaxResources.stone)
                throw new ArgumentOutOfRangeException("Not enought place in heap");
            if (CurrentResources.dewdrop + resources.dewdrop > MaxResources.dewdrop)
                throw new ArgumentOutOfRangeException("Not enought place in heap");

            CurrentResourcesValue = new(CurrentResourcesValue.branch + resources.branch,
                                     CurrentResourcesValue.leaf + resources.leaf,
                                     CurrentResourcesValue.stone + resources.stone,
                                     CurrentResourcesValue.dewdrop + resources.dewdrop);
        }
        public void TakeResources(Resources resources)
        {
            if (CurrentResourcesValue.branch < resources.branch)
                throw new ArgumentOutOfRangeException("Not enought resources in heap");
            if (CurrentResourcesValue.leaf < resources.leaf)
                throw new ArgumentOutOfRangeException("Not enought resources in heap");
            if (CurrentResourcesValue.stone < resources.stone)
                throw new ArgumentOutOfRangeException("Not enought resources in heap");
            if (CurrentResourcesValue.dewdrop < resources.dewdrop)
                throw new ArgumentOutOfRangeException("Not enought resources in heap");

            CurrentResourcesValue = new(CurrentResourcesValue.branch - resources.branch,
                                     CurrentResourcesValue.leaf - resources.leaf,
                                     CurrentResourcesValue.stone - resources.stone,
                                     CurrentResourcesValue.dewdrop - resources.dewdrop);
        }
        public Resources TryTakeResources(Resources resources)
        {
            Resources result = new(
                (CurrentResourcesValue.branch < resources.branch) ? CurrentResourcesValue.branch : resources.branch,
                (CurrentResourcesValue.leaf < resources.leaf) ? CurrentResourcesValue.leaf : resources.leaf,
                (CurrentResourcesValue.stone < resources.stone) ? CurrentResourcesValue.stone : resources.stone,
                (CurrentResourcesValue.dewdrop < resources.dewdrop) ? CurrentResourcesValue.dewdrop : resources.dewdrop
                );

            TakeResources(result);
            return result;
        }
        //========================================================
    }
}
