using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Colonies.Red
{
    class AdvancedWarrior : Warrior
    {
        public AdvancedWarrior(Queen queen)
        : base(new(new(1, 2), new("<Advanced><Red><Warrior>", 6, 3, 2)), queen) { }
    }
}

