using AntsColonies.Notifications;
using System.Collections.Generic;
using AntsColonies.Interfaces;
using AntsColonies.Locations;

namespace AntsColonies.Units
{
    class BaseUnitStateMachine : IStateMachine
    {
        public IState CurrentState { get; set; }
        public void Notify(INotification notification) => CurrentState?.Notify(notification);
        public void Vote(IVoting voting) => CurrentState?.Vote(voting);
    }
    abstract class BaseUnit : IEventHandler
    {
        private static int GlobalUnitId = 0;
        public int UnitId { get; } = ++GlobalUnitId;
        //======================================================
        protected class UnitDeathState : IState
        {
            protected BaseUnit Owner { get; set; }
            public UnitDeathState(BaseUnit owner)
            {
                Owner = owner;
                Owner.GlobalNotificator.Notify(new UnitDeathNotification(Owner));
            }
            public virtual void Notify(INotification notification) { }
            public virtual void Vote(IVoting voting) { }
        }

        public string Name { get; }
        public int Armor { get; protected set; }
        public int Health { get; protected set; }
        public HashSet<Heap> ResourceHeapsList { get; }
        public INotificationReceiver GlobalNotificator { get; }
        protected BaseUnitStateMachine StateMachine { get; set; } = new();

        public BaseUnit(string name, int armor, int health, HashSet<Heap> heaps, INotificationReceiver notificator)
        {
            Name = name;
            Armor = armor;
            Health = health;
            ResourceHeapsList = heaps;
            GlobalNotificator = notificator;

            GlobalNotificator.Notify(new UnitBornedNotification(this));
        }
        public virtual void Notify(INotification notification) => StateMachine.Notify(notification);
        public virtual void Vote(IVoting voting) => StateMachine.Vote(voting);
    }
}
