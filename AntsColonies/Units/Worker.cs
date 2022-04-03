using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Units
{
    class Worker : Hiking
    {
        public WorkerBackpack Backpack { get; }
        public Worker(WorkerBackpack backpack, UnitInfo info, Queen queen) 
        : base(info, queen)
        {
            Backpack = backpack;
            InstallModifier(new PutResourcesToAnthillOnNight(this, Backpack));
            InstallModifier(new TakeResourcesFromHeapOnDay(this, Backpack));
        }
    }
}
