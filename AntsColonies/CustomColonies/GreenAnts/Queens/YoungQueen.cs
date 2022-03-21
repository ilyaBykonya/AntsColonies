using AntsColonies.Notifications;
using System.Collections.Generic;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using System;

namespace AntsColonies.GreenAnts
{
    class YoungQueen : BaseYoungAntQueen
    {
        public YoungQueen(BaseAdultAntQueen parent)
        : base("Victory-child", 28, 9, new() { typeof(SimpleWarrior), typeof(SimpleAnomalyWarrior), typeof(AdvancedWorker), typeof(EliteWorker), typeof(SimpleSprinterWorker) }, parent)
        => StateMachine.CurrentState = new AntQueenLaysLarvaeState(this);

        public override void Vote(IVoting voting) => StateMachine.Vote(voting);
        public override void Notify(INotification notification) => StateMachine.Notify(notification);
    }
}
