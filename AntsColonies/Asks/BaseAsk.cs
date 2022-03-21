using System.Collections.Generic;
using AntsColonies.Interfaces;
using AntsColonies.Units;
using System;

namespace AntsColonies.Asks
{
    class BaseAsk: IVoting
    {
        protected bool? VotingResultValue = null;
        public bool? VotingResult => VotingResultValue;
        public void Reject() => VotingResultValue = false;

        public IVoter Voter { get; }
        public HashSet<IVoter> Voters => new() { Voter };

        public BaseAsk(IVoter voter) => Voter = voter;
        public virtual void ExecuteVoting() => Voter.Vote(this);
    }
}
