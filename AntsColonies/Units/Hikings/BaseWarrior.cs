using System.Collections.Generic;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using System;

namespace AntsColonies.Units
{
    abstract class BaseWarrior : BaseHiking
    {
        protected abstract class BaseWarriorOnAnthillState : BaseHikingOnAnthillState
        {
            protected new readonly BaseWarrior Owner;
            public BaseWarriorOnAnthillState(BaseWarrior owner)
            : base(owner) => Owner = owner;
        }
        protected abstract class BaseWarriorOnHeapState : BaseHikingOnHeapState
        {
            protected new readonly BaseWarrior Owner;
            public BaseWarriorOnHeapState(BaseWarrior owner, Heap heap)
            : base(owner, heap) => Owner = owner;
        }

        public int Damage { get; }
        protected BaseWarrior(string name, int health, int armor, int damage, BaseAntQueen queen)
        : base(name, health, armor, queen) => Damage = damage;
    }
}
