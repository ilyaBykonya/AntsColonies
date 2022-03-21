using AntsColonies.Notifications;
using System.Collections.Generic;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using System;

namespace AntsColonies.RedAnts
{
    class YoungQueen : BaseYoungAntQueen
    {
        public YoungQueen(BaseAdultAntQueen parent)
        : base("Mary-child", 25, 9, new() { typeof(AdvancedWarrior), typeof(EliteSkinnyWarrior), typeof(LegendaryWarrior), typeof(EliteWorker), typeof(AdvancedWorker), typeof(AdvancedQueensPet) }, parent)
        => StateMachine.CurrentState = new AntQueenLaysLarvaeState(this);

        public override void Vote(IVoting voting) => StateMachine.Vote(voting);
        public override void Notify(INotification notification) => StateMachine.Notify(notification);
    }
}
