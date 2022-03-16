using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Base.Units.HikingUnits
{
    abstract class BaseHikingUnit : BaseUnit
    {
        protected abstract class BaseHikingOnAnthillState : BaseState
        {
            protected readonly Anthill Anthill;
            public BaseHikingOnAnthillState(IEventHandler handler, Anthill anthill) : base(handler) => Anthill = anthill;
        }
        protected abstract class BaseHikingOnHeapState : BaseState
        {
            protected readonly ResourcesHeap Heap;
            public BaseHikingOnHeapState(IEventHandler handler, ResourcesHeap heap) : base(handler) => Heap = heap;
        }
        protected abstract class BaseHikingOnHikingState : BaseState
        {
            public BaseHikingOnHikingState(IEventHandler handler) : base(handler) { }
        }

        public YoungAntQueen Queen { get; }
        public BaseState UnitState { get; set; } = null;
        public int Armor { get; protected set; }
        protected BaseHikingUnit(YoungAntQueen queen, string name, int health, int armor) : base(name, health)
        {
            Queen = queen;
            Armor = armor;
        }
    }
}
