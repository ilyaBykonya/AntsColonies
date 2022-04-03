using AntsColonies.Locations;
using AntsColonies.Units;
using System.Collections.Generic;

namespace AntsColonies.Units
{
    abstract class Hiking : Unit
    {
        public Queen Queen { get; }
        public Hiking(UnitInfo info, Queen queen)
        : base(info, queen.QueenInfo.Anthill, queen.Simulation)
        {
            Queen = queen;
            InstallModifier(new WalkOnHeapInTheMorning(this));
            InstallModifier(new WalkOnHomeInTheEvening(this));
        }
    }
}
