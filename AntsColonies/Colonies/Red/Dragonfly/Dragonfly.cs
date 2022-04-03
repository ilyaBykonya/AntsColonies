using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Colonies.Red
{
    class Dragonfly : Hiking
    {
        public WorkerBackpack Backpack { get; } = new(ResourceCode.Dewdrop, ResourceCode.Dewdrop, ResourceCode.Dewdrop);
        public Dragonfly(Queen queen) 
        : base(new("<Green><Dragonfly>", 27, 11, 9), queen)
        {
            InstallModifier(new PutResourcesToAnthillOnNight(this, Backpack));
            InstallModifier(new TakeResourcesFromHeapOnDay(this, Backpack));
            InstallModifier(new Pickpocket(this, Backpack));
            InstallModifier(new Skinny(this));

            InstallModifier(new StartFightOnDay(this));
            InstallModifier(new GetCountOfTargets(this, 2));
            InstallModifier(new GetCountOfHits(this, 1));
            InstallModifier(new GetDamage(this));
            InstallModifier(new GetStandardHit(this));
            InstallModifier(new GetStandardAttackTargets(this));
        }
    }
}
