using System.Collections.Generic;
using AntsColonies.Notifications;
using AntsColonies.Interfaces;
using AntsColonies.Units;
using System;

namespace AntsColonies.Actions
{
    abstract class StandardVotingAction: IVoting, IAction
    {
        private bool? VotingResultValue = null;
        public void Reject() => VotingResultValue = false;
        public bool? VotingResult => VotingResultValue;
        public HashSet<IVoter> Voters { get; }

        public StandardVotingAction(HashSet<IVoter> voters) => Voters = voters;
        public virtual void ExecuteVoting()
        {
            VotingResultValue = true;
            foreach (var voter in Voters)
                voter.Vote(this);
        }
        public abstract void ExecuteAction();
    }
}
