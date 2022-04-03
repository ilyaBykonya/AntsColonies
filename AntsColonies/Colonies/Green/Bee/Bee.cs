using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;


namespace AntsColonies.Colonies.Green
{
    class Bee : Hiking
    {
        public Bee(Queen queen) 
        : base(new("<Green><Bee>", 24, 7, 9), queen)
        {
            InstallModifier(new Avenger(this));
            InstallModifier(new Invulnerable(this));
            InstallModifier(new StartFightOnDay(this));
            InstallModifier(new GetCountOfTargets(this, 3));
            InstallModifier(new GetCountOfHits(this, 3));
            InstallModifier(new GetDamage(this));
            InstallModifier(new GetStandardHit(this));
            InstallModifier(new GetStandardAttackTargets(this));
        }
    }
}
