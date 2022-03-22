using System.Collections.Generic;
using AntsColonies.Notifications;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Actions;
using AntsColonies.Units;
using AntsColonies.Asks;
using System.Linq;
using System;

namespace AntsColonies
{
    class ApplicationExecutor : INotificationReceiver, 
        INotificationReceiver<LifeCycleNotification<BaseUnit>>, 
        INotificationReceiver<LifeCycleNotification<BaseAntQueen>>,
        INotificationReceiver<BattleStartNotification>
    {
        private int DaysToDry { get; } = 12;
        private HashSet<Heap> Heaps { get; } = new();
        private HashSet<BaseAntQueen> Queens { get; } = new();
        private HashSet<INotificationReceiver> Receivers { get; } = new();




        public ApplicationExecutor()
        {
            /*
             Куча 1 ресурсы: веточка: 46; листик: 35; росинка: 42;
             Куча 2 ресурсы: веточка: 33; камушек: 49; росинка: 20;
             Куча 3 ресурсы: веточка: 36; листик: 23;
             Куча 4 ресурсы: веточка: 22; листик: 32; росинка: 13;
             Куча 5 ресурсы: веточка: 19; листик: 34; камушек: 35; росинка: 22;
             */
            Heaps.Add(CreateHeap(46, 35, 0, 42));
            Heaps.Add(CreateHeap(33, 0, 49, 20));
            Heaps.Add(CreateHeap(36, 23, 0, 0));
            Heaps.Add(CreateHeap(22, 32, 0, 13));
            Heaps.Add(CreateHeap(19, 34, 35, 22));

            var redQueen = new RedAnts.AdultQueen(Heaps, this);
            var greenQueen = new GreenAnts.AdultQueen(Heaps, this);
            new RedAnts.Dragonfly(redQueen);
            new GreenAnts.Bee(greenQueen);

            foreach (var heap in Heaps)
                Receivers.Add(heap);

            Receivers.Add(new SongCicade.SongCicade(Heaps, DaysToDry));
        }
        static private Heap CreateHeap(int branches, int leafs, int stones, int drewdrops)
        {
            LinkedList<Resource> startHeapStorage = new();
            for (int i = 0; i < branches; ++i)
                startHeapStorage.AddLast(new Resource(ResourceCode.Branch));
            for (int i = 0; i < leafs; ++i)
                startHeapStorage.AddLast(new Resource(ResourceCode.Leaf));
            for (int i = 0; i < stones; ++i)
                startHeapStorage.AddLast(new Resource(ResourceCode.Stone));
            for (int i = 0; i < drewdrops; ++i)
                startHeapStorage.AddLast(new Resource(ResourceCode.Dewdrop));

            return new(startHeapStorage);
        }


        public void ExecuteSimulation()
        {
            for (int day = 0; day < DaysToDry; ++day)
            {
                System.Console.WriteLine("===========Morning=============");
                SendNotificationToAllReceivers(new MorningNotification());
                System.Console.WriteLine("===============================");
                System.Console.WriteLine($"===========Day [{day}]=========");
                SendNotificationToAllReceivers(new DayNotification());
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("===========Evening=============");
                SendNotificationToAllReceivers(new EveningNotification());
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("===========Night===============");
                SendNotificationToAllReceivers(new NightNotification());
                System.Console.WriteLine("===============================");
            }
        }
        private void SendNotificationToAllReceivers(INotification notification)
        {
            var fixedNotificationReceivers = new INotificationReceiver[Receivers.Count];
            Receivers.CopyTo(fixedNotificationReceivers);
            foreach (var receiver in fixedNotificationReceivers)
                receiver.Notify(notification);
        }
        public void PrintSimulatingResult()
        {
            var winner = Queens.OrderByDescending(queen => queen.OwnAnthill.CountOfResources).First();
            Console.WriteLine($"Winner: [{winner.Name}] - [{winner.UnitId}] - [{winner.OwnAnthill.CountOfResources}]");
        }

        public void Notify(LifeCycleNotification<BaseAntQueen> notification)
        {
            switch(notification)
            {
                case QueenBanishedFromAnthill:
                    {
                        Queens.Add(notification.Unit);
                        Receivers.Add(notification.Unit.OwnAnthill);
                        break;
                    }
                case QueenDeathNotification:
                    {
                        Queens.Remove(notification.Unit);
                        Receivers.Remove(notification.Unit.OwnAnthill);
                        break;
                    }
            }
            SendNotificationToAllReceivers(notification);
        }
        public void Notify(LifeCycleNotification<BaseUnit> notification)
        {
            switch (notification)
            {
                case UnitBornedNotification:
                    Receivers.Add(notification.Unit);
                    break;
                case UnitDeathNotification:
                    Receivers.Remove(notification.Unit);
                    break;
            }
        }
        public void Notify(BattleStartNotification notification)
        {
            GiveMeYourBeatRequest hit1 = new(notification.Location, notification.Units.Item1);
            GiveMeYourBeatRequest hit2 = new(notification.Location, notification.Units.Item2);
            Console.WriteLine($"Battle: [{notification.Units.Item1.UnitId}] <=> [{notification.Units.Item2.UnitId}]");
            notification.Units.Item1.Vote(hit2);
            notification.Units.Item2.Vote(hit1);
            hit1.Hit?.ExecuteVoting();
            hit2.Hit?.ExecuteVoting();
            hit1.Hit?.ExecuteAction();
            hit2.Hit?.ExecuteAction();
        }
        public void Notify(INotification notification)
        {
            Console.WriteLine(notification);
            if (notification is LifeCycleNotification<BaseAntQueen>)
                Notify(notification as LifeCycleNotification<BaseAntQueen>);
            else if(notification is LifeCycleNotification<BaseUnit>)
                Notify(notification as LifeCycleNotification<BaseUnit>);
            else if(notification is BattleStartNotification)
                Notify(notification as BattleStartNotification);


            SendNotificationToAllReceivers(notification);
        }
    }
}
