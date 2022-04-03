using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AntsColonies
{
    class ApplicationExecutor : 
        IEventHandler, 
        IEventHandler<LocationFoundation>,
        IEventHandler<SubscribeActor>,
        IEventHandler<UnsubscribeActor>
    {
        private int DaysToDry { get; } = 12;
        private Simulation Simulation { get; }
        private HashSet<IEventHandler> Subhandlers { get; } = new();

        public ApplicationExecutor()
        {
            Subhandlers.Add(Simulation = new(new GlobalMap(this), this));

            Heap CreateHeap(int branches, int leafs, int stones, int drewdrops)
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

                return new(startHeapStorage, this);
            }
            CreateHeap(46, 35, 0, 42);
            //CreateHeap(33, 0, 49, 20);
            //CreateHeap(36, 23, 0, 0);
            //CreateHeap(22, 32, 0, 13);
            //CreateHeap(19, 34, 35, 22);

            new Colonies.SongCicade.SongCicade(DaysToDry, Simulation);
            new Colonies.Green.AdultGreenQueen(Simulation);
        }
        public void ExecuteSimulation()
        {
            for (int day = 0; day < DaysToDry; ++day)
            {
                System.Console.WriteLine("===========Morning=============");
                HandleEvent(new MorningNotification());
                System.Console.WriteLine("===============================");
                System.Console.WriteLine($"===========Day [{day}]=========");
                HandleEvent(new DayNotification());
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("===========Evening=============");
                HandleEvent(new EveningNotification());
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("===========Night===============");
                HandleEvent(new NightNotification());
                System.Console.WriteLine("===============================");
            }
            PrintSimulationResult();
        }
        public void PrintSimulationState()
        {
            static void PrintQueenInfo(Queen queen)
            {
                Console.WriteLine($"[{queen.UnitInfo.Name}][{queen.Id}][{queen.QueenInfo.Children.Count}][{queen.QueenInfo.Anthill.Resources.Count}]");
            }
            var queens = Subhandlers.Where(handler => handler is Queen).
                Select(handler => handler as Queen).
                OrderByDescending(queen => queen.QueenInfo.Anthill.Resources.Count);

            foreach (var q in queens)
                PrintQueenInfo(q);
        }
        private void PrintSimulationResult()
        {
            var queen = Subhandlers.Where(handler => handler is Queen).
                   Select(handler => handler as Queen).
                   OrderByDescending(queen => queen.QueenInfo.Anthill.Resources.Count).
                   FirstOrDefault();

            Console.WriteLine("Winner");
            if (queen is not null)
            {
                Console.WriteLine($"[{queen.UnitInfo.Name}][{queen.Id}][{queen.QueenInfo.Anthill.Resources.Count}]");
            }
            else
            {
                Console.WriteLine("[No winner queen]");
            }
        }

        public void HandleEvent(IEvent e)
        {
            Console.WriteLine($"Event handled: {e}");
            if (e is LocationFoundation)
                HandleEvent(e as LocationFoundation);
            if (e is SubscribeActor)
                HandleEvent(e as SubscribeActor);
            if (e is UnsubscribeActor)
                HandleEvent(e as UnsubscribeActor);

            Subhandlers.ToList().ForEach(location => location.HandleEvent(e));
        }
        public void HandleEvent(LocationFoundation e) => Subhandlers.Add(e.Location);
        public void HandleEvent(SubscribeActor e) => Subhandlers.Add(e.Actor);
        public void HandleEvent(UnsubscribeActor e) => Subhandlers.Remove(e.Actor);
    }
}
