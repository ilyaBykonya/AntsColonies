using AntsColonies.Notifications;
using System.Collections.Generic;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using System;

namespace AntsColonies.GreenAnts
{
    class AdultQueen : BaseAdultAntQueen
    {
        public AdultQueen(HashSet<Heap> heaps, INotificationReceiver notificator)
        : base("Victory", 28, 9, heaps, notificator, new() { typeof(SimpleWarrior), typeof(SimpleAnomalyWarrior), typeof(AdvancedWorker), typeof(EliteWorker), typeof(SimpleSprinterWorker), typeof(YoungQueen) }, (1, 4), (2, 4))
        => StateMachine.CurrentState = new AntQueenLaysLarvaeState(this);

        public override void Notify(INotification notification)
        {
            if (notification is LifeCycleNotification<BaseAntQueen>)
            {
                var lifeCycleNotification = notification as LifeCycleNotification<BaseAntQueen>;
                var youngQueen = lifeCycleNotification.Unit as YoungQueen;
                if (youngQueen == null)
                    return;

                if (lifeCycleNotification is QueenBanishedFromAnthill)
                    Children.Add(youngQueen);
                else if (lifeCycleNotification is QueenDeathNotification)
                    Children.Remove(youngQueen);
            }
            else
            {
                base.Notify(notification);
            }
        }
    }
}
