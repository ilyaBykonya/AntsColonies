using System.Collections.Generic;
using AntsColonies.Notifications;
using AntsColonies.Interfaces;
using AntsColonies.Units;
using System;


namespace AntsColonies.Asks
{
    class BattleRequest: BaseAsk
    {
        public BaseHiking Damager { get; }
        public BaseHiking Target { get; }
        public BattleRequest(BaseHiking damager, BaseHiking target)
        :base(target)
        {
            Damager = damager;
            Target = target;
        }

        public override void ExecuteVoting()
        {
            VotingResultValue = true;
            base.ExecuteVoting();
        }
    }
}
