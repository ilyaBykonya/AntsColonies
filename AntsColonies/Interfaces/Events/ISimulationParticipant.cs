namespace AntsColonies.Interfaces
{
    interface ISimulationParticipant
    {
        public IEventRouter EventRouter { get; }
    }
}
