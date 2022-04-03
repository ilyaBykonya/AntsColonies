using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Colonies.Green
{
    class AnomalyWarrior : Warrior
    {
        public AnomalyWarrior(Queen queen)
        : base(new(new(1, 1), new("<Simple><Anomaly><Green><Warrior>", 1, 1, 0)), queen) 
        {
            InstallModifier(new GetAnomalyAttackTargets(this));
        }
    }
}
