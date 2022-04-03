namespace AntsColonies.Interfaces
{
    abstract class SimulationActor : ISimulationParticipant, IEventHandler
    {
        public Simulation Simulation { get; }
        public IEventHandler EventRouter => Simulation.EventRouter;

        public SimulationActor(Simulation simulation) => Simulation = simulation;
        public abstract void HandleEvent(IEvent e);
    }
}
