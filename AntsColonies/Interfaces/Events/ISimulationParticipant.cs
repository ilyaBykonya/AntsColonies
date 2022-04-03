namespace AntsColonies.Interfaces
{
    interface ISimulationParticipant
    {
        public IEventHandler EventRouter { get; }
    }
}
