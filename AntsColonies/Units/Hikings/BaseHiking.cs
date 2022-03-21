using AntsColonies.Notifications;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using System;

namespace AntsColonies.Units
{
    abstract class BaseHiking : BaseUnit
    {
        protected abstract class BaseHikingOnAnthillState : IState
        {
            protected BaseHiking Owner { get; set; }
            protected Anthill Anthill => Owner.Queen.OwnAnthill;

            public BaseHikingOnAnthillState(BaseHiking owner)
            {
                Owner = owner;
                Owner.GlobalNotificator.Notify(new UnitCameToAnthill(Owner, Anthill));
            }
            public virtual void Notify(INotification notification)
            {
                if (notification is BaseReduceHealthNotification)
                {
                    var reduce = notification as BaseReduceHealthNotification;
                    if (reduce != null && reduce.Unit == Owner)
                        if ((Owner.Health -= reduce.Damage) <= 0)
                            Owner.StateMachine.CurrentState = new UnitDeathState(Owner);
                }
            }
            public virtual void Vote(IVoting voting) { }
        }
        protected abstract class BaseHikingOnHeapState : IState
        {
            protected BaseHiking Owner { get; set; }
            protected Heap Heap { get; }

            public BaseHikingOnHeapState(BaseHiking owner, Heap heap)
            {
                Owner = owner;
                Heap = heap;
                Owner.Queen.GlobalNotificator.Notify(new UnitCameToHeap(Owner, Heap));
            }
            public virtual void Notify(INotification notification)
            {
                if (notification is BaseReduceHealthNotification)
                {
                    var reduce = notification as BaseReduceHealthNotification;
                    if (reduce.Unit == Owner)
                        if ((Owner.Health -= reduce.Damage) <= 0)
                            Owner.StateMachine.CurrentState = new UnitDeathState(Owner);
                }
            }
            public virtual void Vote(IVoting voting) { }
        }

        public BaseAntQueen Queen { get; }
        protected BaseHiking(string name, int health, int armor, BaseAntQueen queen)
        : base(name, armor, health, queen.ResourceHeapsList, queen.GlobalNotificator)
        { Queen = queen; }
    }
}
