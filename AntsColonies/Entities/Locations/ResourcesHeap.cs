using System;
using System.Collections.Generic;

namespace AntsColonies
{
    class ResourcesHeap : IResourceStorage, IEventHandler
    {
        public LinkedList<IEventHandler> EventHandlersList { get; } = new();
        public ResourcesHeap(Resources resources) => RemainingResources = resources;

        public void HandleEvent(IEvent e)
        {
            foreach (var handler in EventHandlersList)
            {
                if (e.HandleResult == false)
                    return;

                handler.HandleEvent(e);
            }
        }




        //========================================================
        private Resources RemainingResources;

        public Resources CurrentResources => RemainingResources;
        public Resources MaxResources => new(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);

        public void PutResources(Resources resources)
        {
            RemainingResources = new(RemainingResources.branch + resources.branch,
                                     RemainingResources.leaf + resources.leaf,
                                     RemainingResources.stone + resources.stone,
                                     RemainingResources.dewdrop + resources.dewdrop);
        }
        public void TakeResources(Resources resources)
        {
            if (RemainingResources.branch < resources.branch)
                throw new ArgumentOutOfRangeException("Not enought resources in heap");
            if (RemainingResources.leaf < resources.leaf)
                throw new ArgumentOutOfRangeException("Not enought resources in heap");
            if (RemainingResources.stone < resources.stone)
                throw new ArgumentOutOfRangeException("Not enought resources in heap");
            if (RemainingResources.dewdrop < resources.dewdrop)
                throw new ArgumentOutOfRangeException("Not enought resources in heap");

            RemainingResources = new(RemainingResources.branch - resources.branch,
                                     RemainingResources.leaf - resources.leaf,
                                     RemainingResources.stone - resources.stone,
                                     RemainingResources.dewdrop - resources.dewdrop);
        }
        public Resources TryTakeResources(Resources resources)
        {
            Resources result = new(
                (RemainingResources.branch < resources.branch) ? RemainingResources.branch : resources.branch,
                (RemainingResources.leaf < resources.leaf) ? RemainingResources.leaf : resources.leaf,
                (RemainingResources.stone < resources.stone) ? RemainingResources.stone : resources.stone,
                (RemainingResources.dewdrop < resources.dewdrop) ? RemainingResources.dewdrop : resources.dewdrop
                );

            TakeResources(result);
            return result;
        }
        //========================================================
    }
}
