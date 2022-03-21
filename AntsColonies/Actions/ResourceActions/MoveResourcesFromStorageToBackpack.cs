using System.Collections.Generic;
using AntsColonies.Interfaces;
using AntsColonies.Units;
using System;

namespace AntsColonies.Actions
{
    class MoveResourcesFromStorageToBackpack: StandardVotingAction
    {
        public IResourceStorage Storage { get; }
        public WorkerBackpack Backpack { get; }

        public MoveResourcesFromStorageToBackpack(IResourceStorage storage, WorkerBackpack backpack)
        :base(new() { storage, backpack })
        {
            Backpack = backpack;
            Storage = storage;
        }
        public override void ExecuteAction()
        {
            if (VotingResult != true)
                return;

            if (Storage.CountOfResources > 0)
                Console.WriteLine("\t[Move resources from storage to backpack]");

            foreach (var type in Backpack.Types)
            {
                Resource moved = Storage.TakeResource(type);
                if (moved == null) { continue; }
                if (Backpack.PutResource(moved) == true) 
                {
                    Console.WriteLine($"\t\t[{moved}]");
                }
                else
                {
                    Storage.PutResource(moved);
                }
            }
        }
    }
}
