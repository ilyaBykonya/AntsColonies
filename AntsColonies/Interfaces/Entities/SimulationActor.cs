using System.Collections.Generic;

namespace AntsColonies.Interfaces
{
    abstract class SimulationActor : ISimulationParticipant, IEventRouter
    {
        private static int GlobalUnitId = 0;//Все актёры индексируются
        public int Id { get; } = ++GlobalUnitId;

        //Simulation - класс, содержащий информацию о симуляции:
        //списки куч и королев, ссылку на глобальную карту.
        public Simulation Simulation { get; }
        public IEventRouter EventRouter => Simulation.EventRouter;

        private StandardEventRouter Router { get; } = new();
        public IReadOnlyCollection<IEventHandler> Subhandlers => Router.Subhandlers;
        public virtual void SubscribeSubhandler(IEventHandler handler) => Router.SubscribeSubhandler(handler);
        public virtual void UnsubscribeSubhandler(IEventHandler handler) => Router.UnsubscribeSubhandler(handler);
        public virtual void HandleEvent(IEvent e) => Router.HandleEvent(e);

        public SimulationActor(Simulation simulation)
        => (Simulation = simulation).EventRouter.SubscribeSubhandler(this);
    }
}
