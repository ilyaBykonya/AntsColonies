using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Units
{
    record WarriorParameters(int CountOfHits, int CountOfTargets);
    class Warrior : Hiking
    {
        public Warrior((WarriorParameters, UnitInfo) info, Queen queen)
        : base(info.Item2, queen)
        {
            InstallModifier(new StartFightOnDay(this));
            InstallModifier(new GetCountOfTargets(this, info.Item1.CountOfTargets));
            InstallModifier(new GetCountOfHits(this, info.Item1.CountOfHits));
            InstallModifier(new GetDamage(this));
            InstallModifier(new GetStandardHit(this));
            InstallModifier(new GetStandardAttackTargets(this));
        }
    }
}
