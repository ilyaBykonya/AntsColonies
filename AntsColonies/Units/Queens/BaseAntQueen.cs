using System.Collections.Generic;
using AntsColonies.Notifications;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using System.Reflection;
using System.Linq;
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
                {
                    Queen.StateMachine.CurrentState = new AntQueenTakingCareLarvaeState(Queen);
                }
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
                        Queen.Children.Add(newUnit);
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
        public override void Notify(INotification notification)
        {
            if(notification is NightNotification)
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("Anthill");
                Console.WriteLine($"\tQueen [{Name}] - [{UnitId}]");
                Console.WriteLine($"\tResources: [{OwnAnthill.CountOfResources}]");
                Console.WriteLine($"\tChildren: [{Children.Count}]");
                Console.WriteLine($"\t\tWarriors: [{Children.Count(unit => unit is BaseWarrior)}]");
                Console.WriteLine($"\t\tWorkers: [{Children.Count(unit => unit is BaseWorker)}]");
                Console.WriteLine($"\t\tQueens: [{Children.Count(unit => unit is BaseAntQueen)}]");
                Console.WriteLine("==================================================");
            }
            else if(notification is UnitDeathNotification)
            {
                var death = notification as UnitDeathNotification;
                var hiking = (death.Unit as BaseHiking);
                if (hiking != null)
                {
                    if (hiking.Queen == this)
                        Children.Remove(hiking);
                }
            }
            base.Notify(notification);
        }
    }
}
