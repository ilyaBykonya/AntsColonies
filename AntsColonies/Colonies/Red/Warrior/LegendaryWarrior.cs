using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Colonies.Red
{
    class LegendaryWarrior : Warrior
    {
        public LegendaryWarrior(Queen queen)
        : base(new(new(1, 3), new("<Legendary><Red><Warrior>", 10, 6, 6)), queen) { }
    }
}


