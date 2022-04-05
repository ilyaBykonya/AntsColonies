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
        IEventRouter, IEventHandler<LocationFoundation<Location>>
    {
        private int DaysToDry { get; } = 12;
        private Simulation Simulation { get; }

        private StandardEventRouter Router { get; } = new();
        public IReadOnlyCollection<IEventHandler> Subhandlers => Router.Subhandlers;
        public void SubscribeSubhandler(IEventHandler handler) => Router.SubscribeSubhandler(handler);
        public void UnsubscribeSubhandler(IEventHandler handler) => Router.UnsubscribeSubhandler(handler);

        public void HandleEvent(IEvent e)
        {
            Console.WriteLine($"Event handled: {e}");
            if (e is LocationFoundation<Location>)
                HandleEvent(e as LocationFoundation<Location>);

            Router.HandleEvent(e);
        }
        public void HandleEvent(LocationFoundation<Location> e) => SubscribeSubhandler(e.Location);
    
        public ApplicationExecutor()
        {
            Router.SubscribeSubhandler(Simulation = new(new GlobalMap(this), this));

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
            CreateHeap(33, 0, 49, 20);
            CreateHeap(36, 23, 0, 0);
            CreateHeap(22, 32, 0, 13);
            CreateHeap(19, 34, 35, 22);

            CreateRedColony();
            CreateGreenColony();
            new Colonies.SongCicade.SongCicade(DaysToDry, Simulation);
        }

        private Queen CreateGreenColony()
        {
            var queen = new Colonies.Green.AdultGreenQueen(Simulation);
            new Colonies.Green.Bee(queen);
            CreateColony(queen, 19, 8);
            return queen;
        }
        private Queen CreateRedColony()
        {
            var queen = new Colonies.Red.AdultRedQueen(Simulation);
            new Colonies.Red.Dragonfly(queen);
            CreateColony(queen, 13, 7);
            return queen;
        }
        private void CreateColony(Queen queen, int workers, int warriors)
        {
            var warriors_types = queen.QueenParameters.ChildrenTypes.Where(type => type.IsSubclassOf(typeof(Warrior)));
            var workers_types = queen.QueenParameters.ChildrenTypes.Where(type => type.IsSubclassOf(typeof(Worker)));

            Random generator = new();
            if(warriors_types.Count() > 0)
                for(int i = 0; i < warriors; ++i)
                    queen.QueenInfo.Children.Add((Warrior)Activator.CreateInstance(warriors_types.ElementAt(generator.Next(warriors_types.Count())), queen));
                
            if (workers_types.Count() > 0)
                for (int i = 0; i < workers; ++i)
                    queen.QueenInfo.Children.Add((Worker)Activator.CreateInstance(workers_types.ElementAt(generator.Next(workers_types.Count())), queen));
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
    }
}
