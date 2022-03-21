using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies.Interfaces
{
    interface IVoting
    {
        public HashSet<IVoter> Voters { get; }
        public bool? VotingResult { get; }
        public void ExecuteVoting();
        public void Reject();
    }
}
