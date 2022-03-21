using System.Collections.Generic;
using AntsColonies.Notifications;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using System.Reflection;
using System;


namespace AntsColonies.Units
{
    abstract class BaseAntQueen: BaseUnit
    {
        protected class AntQueenLaysLarvaeState : IState
        {
            protected BaseAntQueen Queen { get; }
            public AntQueenLaysLarvaeState(BaseAntQueen queen) => Queen = queen;
            public virtual void Vote(IVoting voting) {}
            public virtual void Notify(INotification notification)
            {
                if (notification is MorningNotification)
                    Queen.StateMachine.CurrentState = new AntQueenTakingCareLarvaeState(Queen);
            }
        }
        protected class AntQueenTakingCareLarvaeState : IState
        {
            protected BaseAntQueen Queen { get; }
            protected int NumberOfLarvae { get; }
            protected int RemainedDays;
            public AntQueenTakingCareLarvaeState(BaseAntQueen queen)
            {
                Queen = queen;
                Random random = new();
                NumberOfLarvae = random.Next(Queen.NumberOfLarvaeRange.Item1, Queen.NumberOfLarvaeRange.Item2);
                RemainedDays = random.Next(Queen.LarvalGrowthTimeRange.Item1, Queen.LarvalGrowthTimeRange.Item2);
            }
            
            public virtual void Vote(IVoting voting) { }
            public virtual void Notify(INotification notification)
            {
                if(notification is DayNotification)
                {
                    --RemainedDays;
                }
                else if(notification is EveningNotification && RemainedDays <= 0)
                {
                    Random generator = new();
                    for(int i = 0; i < NumberOfLarvae; ++i)
                    {
                        var newUnit = (BaseUnit)Activator.CreateInstance(Queen.ChildrenTypes[generator.Next(Queen.ChildrenTypes.Count)], Queen);
                        Console.WriteLine($"Queen born new unit [{Queen.UnitId}] => [{newUnit.UnitId}]");
                    }
                }
            }
        }
        protected class QueenDeathState : UnitDeathState
        {
            public QueenDeathState(BaseAntQueen owner) : base(owner)
            => Owner.GlobalNotificator.Notify(new QueenDeathNotification(owner));
        }


        public Anthill OwnAnthill { get; } = new();
        public List<Type> ChildrenTypes { get; }
        public HashSet<BaseUnit> Children { get; } = new();
        public (int, int) LarvalGrowthTimeRange { get; }
        public (int, int) NumberOfLarvaeRange { get; }

        protected BaseAntQueen(string name, int armor, int health, HashSet<Heap> heaps, INotificationReceiver notificator, List<Type> childrenTypes, (int, int) growthTime, (int, int) numberOfLarvae)
        :base(name, armor, health, heaps, notificator)
        {
            ChildrenTypes = childrenTypes;
            LarvalGrowthTimeRange = growthTime;
            NumberOfLarvaeRange = numberOfLarvae;

            GlobalNotificator.Notify(new QueenBanishedFromAnthill(this));
        }
        public abstract bool IsMyRelate(BaseAntQueen other);
    }
}
