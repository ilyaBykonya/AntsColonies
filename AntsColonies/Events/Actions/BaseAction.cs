using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Events
{
    abstract class BaseAction : ISimulationParticipant, IVoting
    {
        private bool? VotingResultValue;
        public bool? Result => VotingResultValue;
        public HashSet<IEventHandler> Voters { get; } = new();
        public IEventHandler EventRouter{ get; }
        public BaseAction(IEventHandler router) => EventRouter = router;

        public virtual bool Execute()
        {
            bool result = Vote();
            if (result) { Action(); }
            return result;
        }
        public virtual void Reject() => VotingResultValue = false;
        public abstract void Action();
        public virtual bool Vote()
        {
            VotingResultValue = true;
            foreach (var voter in Voters)
                voter.HandleEvent(this);

            return Result.Value;
        }
    }
}
