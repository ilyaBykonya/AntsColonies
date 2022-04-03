using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Colonies.Green
{
    class SimpleWarrior : Warrior
    {
        public SimpleWarrior(Queen queen) 
        : base(new(new(1, 1), new("<Simple><Green><Warrior>", 1, 1, 0)), queen) { }
    }
}
