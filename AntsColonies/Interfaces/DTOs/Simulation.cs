using System.Collections.Generic;
using AntsColonies.Locations;

namespace AntsColonies.Interfaces
{
    sealed class Simulation : ISimulationParticipant, IEventHandler<AnthillFoundation>, IEventHandler<HeapFoundation>
    {
        private HashSet<Anthill> AnthillsList { get; } = new();
        private HashSet<Heap> HeapsList { get; } = new();
        public IReadOnlyCollection<Anthill> Anthills => AnthillsList;
        public IReadOnlyCollection<Heap> Heaps => HeapsList;
        public IEventHandler EventRouter { get; }
        public GlobalMap GlobalMap { get; }


        public Simulation(GlobalMap map, IEventHandler router)
        {
            EventRouter = router;
            GlobalMap = map;
        }
        public void HandleEvent(IEvent e)
        {
            if (e is GlobalMapFoundation)
                HandleEvent(e as GlobalMapFoundation);
            if (e is AnthillFoundation)
                HandleEvent(e as AnthillFoundation);
            if (e is HeapFoundation)
                HandleEvent(e as HeapFoundation);
        }
        public void HandleEvent(AnthillFoundation e) => AnthillsList.Add(e.Location);
        public void HandleEvent(HeapFoundation e) => HeapsList.Add(e.Location);
    }
}
