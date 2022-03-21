using System.Collections.Generic;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using System;

namespace AntsColonies.Actions
{
    abstract class BaseAttack: StandardVotingAction
    {
        public BaseLocation Place { get; }
        public BaseHiking Target { get; }

        public BaseAttack(BaseLocation place, BaseHiking target)
        : base(new() { place, target })
        {
            Place = place;
            Target = target;
        }
    }
}
