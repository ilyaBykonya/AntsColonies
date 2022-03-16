using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events.Notifications.MovementEvents.GoingEvents;
using AntsColonies.Base.Events.Notifications.TimeLineEvents;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.Queens;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Base.Units.HikingUnits.Warriors
{
    abstract class BaseWarrior : BaseHikingUnit
    {
        protected abstract class BaseWarriorOnAnthillState : BaseHikingOnAnthillState
        {
            protected readonly BaseWarrior Owner;
            public BaseWarriorOnAnthillState(IEventHandler handler, BaseWarrior owner, Anthill anthill)
            : base(handler, anthill) => Owner = owner;
        }
        protected abstract class BaseWarriorOnHeapState : BaseHikingOnHeapState
        {
            protected readonly BaseWarrior Owner;
            public BaseWarriorOnHeapState(IEventHandler handler, BaseWarrior owner, ResourcesHeap heap)
            : base(handler, heap) => Owner = owner;
        }
        protected abstract class BaseWarriorOnHikingState : BaseHikingOnHikingState
        {
            protected readonly BaseWarrior Owner;
            public BaseWarriorOnHikingState(IEventHandler handler, BaseWarrior owner)
            : base(handler) => Owner = owner;
        }


        public int Damage { get; protected set; }
        protected BaseWarrior(YoungAntQueen queen, string name, int health, int armor, int damage) : base(queen, name, health , armor) => Damage = damage;
        public override bool HandleEvent(IEvent e) => UnitState.HandleEvent(e);
    }
}
