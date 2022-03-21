using System.Collections.Generic;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Actions;
using AntsColonies.Units;
using System.Linq;
using System;

namespace AntsColonies.RedAnts
{
    class DragonflyTakeResourceFromHeap : StandardVotingAction
    {
        public Heap Storage { get; }
        public Dragonfly DragonflyUnit { get; }

        public DragonflyTakeResourceFromHeap(Heap storage, Dragonfly dragonfly)
        : base(new() { storage, dragonfly })
        {
            DragonflyUnit = dragonfly;
            Storage = storage;

            foreach (var enemy in Storage.Units.Where(unit => !(unit.Queen.IsMyRelate(DragonflyUnit.Queen) || (unit.Queen == DragonflyUnit.Queen))))
                Voters.Add(enemy);
        }
        public override void ExecuteAction()
        {
            if (VotingResult != true)
                return;
            if (Storage.CountOfResources > 0)
                Console.WriteLine("\t[Move resources from storage to backpack]");

            var enemies = from unit in Storage.Units where
                          (!unit.Queen.IsMyRelate(DragonflyUnit.Queen) &&
                          !(unit.Queen == DragonflyUnit.Queen) &&
                          unit is BaseWorker) select unit;


            foreach (var type in DragonflyUnit.Backpack.Types)
            {
                Resource moved = Storage.TakeResource(type);
                if (moved == null) 
                {
                    foreach(var enemy in enemies)
                    {
                        var backpack = (enemy as BaseWorker).Backpack;
                        var resource = backpack.TakeResource(ResourceCode.Dewdrop);
                        if(resource != null)
                        {
                            DragonflyUnit.Backpack.PutResource(resource);
                            break;
                        }
                    }
                }
                else if (DragonflyUnit.Backpack.PutResource(moved) == true)
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
