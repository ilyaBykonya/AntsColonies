using AntsColonies.Interfaces;
using AntsColonies.Locations;

namespace AntsColonies.Units
{

    abstract class BaseWorker: BaseHiking
    {
        protected abstract class BaseWorkerOnAnthillState : BaseHikingOnAnthillState
        {
            protected new readonly BaseWorker Owner;
            public BaseWorkerOnAnthillState(BaseWorker owner)
            : base(owner) => Owner = owner;
        }
        protected abstract class BaseWorkerOnHeapState : BaseHikingOnHeapState
        {
            protected new readonly BaseWorker Owner;
            public BaseWorkerOnHeapState(BaseWorker owner, Heap heap)
            : base(owner, heap) => Owner = owner;
        }

        public WorkerBackpack Backpack { get; }
        public BaseWorker(string name, int health, int armor, BaseAntQueen queen, WorkerBackpack backpack)
        : base(name, health, armor, queen) => Backpack = backpack;
    }
}
