using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Colonies.Red
{
    class SkinnyWarrior : Warrior
    {
        public SkinnyWarrior(Queen queen)
        : base(new(new(2, 2), new("<Skinny><Red><Warrior>", 8, 3, 4)), queen) 
        {
            InstallModifier(new Skinny(this));
        }
    }
}


