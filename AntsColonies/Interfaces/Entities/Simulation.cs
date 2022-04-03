using System.Collections.Generic;
using AntsColonies.Locations;

namespace AntsColonies.Interfaces
{
    sealed class Simulation : 
        ISimulationParticipant,
        IEventHandler<LocationFoundation<Anthill>>, 
        IEventHandler<LocationFoundation<Heap>>,
        IEventHandler<IEvent>
    {
        private HashSet<Anthill> AnthillsList { get; } = new();
        private HashSet<Heap> HeapsList { get; } = new();
        public IReadOnlyCollection<Anthill> Anthills => AnthillsList;
        public IReadOnlyCollection<Heap> Heaps => HeapsList;
        public IEventRouter EventRouter { get; }
        public GlobalMap GlobalMap { get; }


        public Simulation(GlobalMap map, IEventRouter router)
        {
            EventRouter = router;
            GlobalMap = map;
        }
        public void HandleEvent(IEvent e)
        {
            if (e is LocationFoundation<Anthill>)
                HandleEvent(e as LocationFoundation<Anthill>);
            if (e is LocationFoundation<Heap>)
                HandleEvent(e as LocationFoundation<Heap>);
        }
        public void HandleEvent(LocationFoundation<Anthill> e) => AnthillsList.Add(e.Location);
        public void HandleEvent(LocationFoundation<Heap> e) => HeapsList.Add(e.Location);
    }
}
