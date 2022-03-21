using System.Collections.Generic;
using AntsColonies.Interfaces;
using AntsColonies.Units;
using System;


namespace AntsColonies.Actions
{
    class MoveResourcesFromBackpackToStorage: StandardVotingAction
    {
        public IResourceStorage Storage { get; }
        public WorkerBackpack Backpack { get; }

        public MoveResourcesFromBackpackToStorage(WorkerBackpack backpack, IResourceStorage storage)
        :base(new() { backpack, storage })
        {
            Backpack = backpack;
            Storage = storage;
        }
        public override void ExecuteAction()
        {
            if (VotingResult != true)
                return;

            if (Backpack.CountOfResources > 0)
                Console.WriteLine("\t[Move resources from backpack to storage]");

            for (var moved = Backpack.TakeResource(); moved != null; moved = Backpack.TakeResource())
            {
                if (Storage.PutResource(moved) == true)
                    Console.WriteLine($"\t\t[{moved}]");
                else
                    throw new InvalidOperationException("Fucking invalid storage");
            }
        }
    }
}
