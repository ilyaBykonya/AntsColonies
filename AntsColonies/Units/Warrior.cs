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
        public WarriorParameters WarriorInfo { get; }
        public Warrior((WarriorParameters, UnitInfo) info, Queen queen)
        : base(info.Item2, queen)
        {
            WarriorInfo = info.Item1;
            InstallModifier(new StartFightOnDay(this));
            InstallModifier(new GetCountOfTargets(this));
            InstallModifier(new GetCountOfHits(this));
            InstallModifier(new GetDamage(this));
            InstallModifier(new GetStandardHit(this));
            InstallModifier(new GetStandardAttackTargets(this));
        }
    }
}
